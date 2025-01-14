﻿using DiscordRPC;
using HipHopFile;
using Newtonsoft.Json;
using SharpDX;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace IndustrialPark
{
    public abstract class GenericAssetDataContainer
    {
        [JsonProperty]
        protected Game _game;

        [Browsable(false)]
        public Game game => _game;

        public void SetGame(Game game)
        {
            _game = game;

            var properties = GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(this);

                if (propValue == null)
                    continue;

                if (typeof(GenericAssetDataContainer).IsAssignableFrom(prop.PropertyType))
                    ((GenericAssetDataContainer)propValue).SetGame(game);
                else if (prop.PropertyType.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)) &&
                    typeof(GenericAssetDataContainer).IsAssignableFrom(i.GenericTypeArguments[0])))
                {
                    var gadcs = (IEnumerable<GenericAssetDataContainer>)prop.GetValue(this);
                    if (gadcs != null)
                    {
                        foreach (var gadc in gadcs)
                        {
                            if (gadc != null)
                                gadc.SetGame(game);
                        }
                    }
                }
                
            }
        }

        public abstract void Serialize(EndianBinaryWriter writer);

        public byte[] Serialize(Endianness endianness)
        {
            using (var writer = new EndianBinaryWriter(endianness))
            {
                Serialize(writer);
                return writer.ToArray();
            }
        }

        public virtual bool HasReference(uint assetID)
        {
            var properties = GetType().GetProperties();

            foreach (var prop in properties)
            {
                var propValue = prop.GetValue(this);

                if (propValue == null)
                    continue;

                if (prop.PropertyType.Equals(typeof(AssetID)) && ((AssetID)propValue).Equals(assetID))
                    return true;

                if (typeof(GenericAssetDataContainer).IsAssignableFrom(prop.PropertyType))
                {
                    if (((GenericAssetDataContainer)propValue).HasReference(assetID))
                        return true;
                }

                var interfaces = prop.PropertyType.GetInterfaces();
                foreach (var i in interfaces)
                {
                    if (i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)))
                    {
                        if (i.GenericTypeArguments[0].Equals(typeof(AssetID)))
                        {
                            var enumerable = (IEnumerable<AssetID>)propValue;
                            if (enumerable != null && enumerable.Any(a => a.Equals(assetID)))
                                return true;
                        }
                        else if (typeof(GenericAssetDataContainer).IsAssignableFrom(i.GenericTypeArguments[0]))
                        {
                            var enumerable = (IEnumerable<GenericAssetDataContainer>)propValue;
                            if (enumerable != null && enumerable.Any(a => a != null && a.HasReference(assetID)))
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public virtual void ReplaceReferences(uint oldAssetId, uint newAssetId)
        {
            if (oldAssetId == 0)
                return;

            var typeProperties = GetType().GetProperties();

            foreach (var prop in typeProperties.Where(prop => prop.PropertyType.Equals(typeof(AssetID)) && ((AssetID)prop.GetValue(this)).Equals(oldAssetId)))
                prop.SetValue(this, new AssetID(newAssetId));

            foreach (var gadc in typeProperties.Where(prop => typeof(GenericAssetDataContainer).IsAssignableFrom(prop.PropertyType)).Select(prop => (GenericAssetDataContainer)prop.GetValue(this)))
                gadc?.ReplaceReferences(oldAssetId, newAssetId);

            foreach (var array in typeProperties.Where(prop => prop.PropertyType.Equals(typeof(AssetID[]))).Select(prop => (AssetID[])prop.GetValue(this)))
                for (int i = 0; i < array.Length; i++)
                    if (array[i] == oldAssetId)
                        array[i] = newAssetId;

            foreach (var gadcs in typeProperties.Where(prop => prop.PropertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)) && typeof(GenericAssetDataContainer).IsAssignableFrom(i.GenericTypeArguments[0]))).Select(prop => (IEnumerable<GenericAssetDataContainer>)prop.GetValue(this)))
                foreach (var gadc in gadcs)
                    gadc.ReplaceReferences(oldAssetId, newAssetId);
        }

        public virtual void Verify(ref List<string> result)
        {
            var typeProperties = GetType().GetProperties();

            foreach (var prop in typeProperties.Where(prop => prop.PropertyType.Equals(typeof(AssetID))))
                if (prop.GetCustomAttribute(typeof(IgnoreVerificationAttribute)) == null)
                    Verify((AssetID)prop.GetValue(this), prop.Name, prop.GetCustomAttribute(typeof(ValidReferenceRequiredAttribute)) != null, ref result);

            foreach (var gadc in typeProperties.Where(prop => typeof(GenericAssetDataContainer).IsAssignableFrom(prop.PropertyType)).Select(prop => (GenericAssetDataContainer)prop.GetValue(this)))
                gadc.Verify(ref result);

            foreach (var prop in typeProperties.Where(prop => prop.PropertyType.Equals(typeof(AssetID[]))))
                if (prop.GetCustomAttribute(typeof(IgnoreVerificationAttribute)) == null)
                {
                    var array = (AssetID[])prop.GetValue(this);
                    foreach (var assetID in array)
                        Verify(assetID, prop.Name, prop.GetCustomAttribute(typeof(ValidReferenceRequiredAttribute)) != null, ref result);
                }

            foreach (var gadcs in typeProperties.Where(prop => prop.PropertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition().Equals(typeof(IEnumerable<>)) && typeof(GenericAssetDataContainer).IsAssignableFrom(i.GenericTypeArguments[0]))).Select(prop => (IEnumerable<GenericAssetDataContainer>)prop.GetValue(this)))
                foreach (var gadc in gadcs)
                    gadc.Verify(ref result);
        }

        protected static void Verify(uint assetID, string propName, bool validReferenceRequired, ref List<string> result)
        {
            if (assetID != 0 && !Program.MainForm.AssetExists(assetID))
                result.Add($"Asset 0x{assetID:X8} referenced in {propName} was not found in any open archive.");
            if (validReferenceRequired && assetID == 0)
                result.Add($"{propName} is 0");
        }

        public virtual void SetDynamicProperties(DynamicTypeDescriptor dt)
        {
        }

        protected static FlagBitmask ByteFlagsDescriptor(params string[] flagNames) => FlagsDescriptor(8, flagNames);

        protected static FlagBitmask ShortFlagsDescriptor(params string[] flagNames) => FlagsDescriptor(16, flagNames);

        protected static FlagBitmask IntFlagsDescriptor(params string[] flagNames) => FlagsDescriptor(32, flagNames);

        private static FlagBitmask FlagsDescriptor(int bitSize, params string[] flagNames)
        {
            var dt = new FlagBitmask(typeof(FlagField));
            var ff = new FlagField(bitSize, flagNames, dt);
            return dt.DFD_FromComponent(ff);
        }

        protected static float? TriangleIntersection(Ray r, IList<Models.Triangle> triangles, IList<Vector3> vertices, Matrix world)
        {
            float? smallestDistance = null;

            foreach (var t in triangles)
            {
                var v1 = (Vector3)Vector3.Transform(vertices[t.vertex1], world);
                var v2 = (Vector3)Vector3.Transform(vertices[t.vertex2], world);
                var v3 = (Vector3)Vector3.Transform(vertices[t.vertex3], world);

                if (r.Intersects(ref v1, ref v2, ref v3, out float distance))
                {
                    if (smallestDistance == null || distance < smallestDistance)
                        smallestDistance = distance;
                }
            }

            return smallestDistance;
        }
    }
}
