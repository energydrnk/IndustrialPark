﻿using HipHopFile;
using System.Collections.Generic;

namespace IndustrialPark
{
    public class CamSpecific_Generic : GenericAssetDataContainer
    {
        public CamSpecific_Generic() { }
    }

    public class CamSpecific_Follow : CamSpecific_Generic
    {
        public AssetSingle Rotation { get; set; }
        public AssetSingle Distance { get; set; }
        public AssetSingle Height { get; set; }
        public AssetSingle RubberBand { get; set; }
        public AssetSingle StartSpeed { get; set; }
        public AssetSingle EndSpeed { get; set; }

        public CamSpecific_Follow() { }
        public CamSpecific_Follow(EndianBinaryReader reader)
        {
            Rotation = reader.ReadSingle();
            Distance = reader.ReadSingle();
            Height = reader.ReadSingle();
            RubberBand = reader.ReadSingle();
            StartSpeed = reader.ReadSingle();
            EndSpeed = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Rotation);
            writer.Write(Distance);
            writer.Write(Height);
            writer.Write(RubberBand);
            writer.Write(StartSpeed);
            writer.Write(EndSpeed);
            return writer.ToArray();
        }
    }

    public class CamSpecific_Shoulder : CamSpecific_Generic
    {
        public AssetSingle Distance { get; set; }
        public AssetSingle Height { get; set; }
        public AssetSingle RealignSpeed { get; set; }
        public AssetSingle RealignDelay { get; set; }

        public CamSpecific_Shoulder() { }
        public CamSpecific_Shoulder(EndianBinaryReader reader)
        {
            Distance = reader.ReadSingle();
            Height = reader.ReadSingle();
            RealignSpeed = reader.ReadSingle();
            RealignDelay = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Distance);
            writer.Write(Height);
            writer.Write(RealignSpeed);
            writer.Write(RealignDelay);
            return writer.ToArray();
        }
    }

    public class CamSpecific_Static : CamSpecific_Generic
    {
        public int Unused { get; set; }

        public CamSpecific_Static() { }
        public CamSpecific_Static(EndianBinaryReader reader)
        {
            Unused = reader.ReadInt32();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Unused);
            return writer.ToArray();
        }
    }

    public class CamSpecific_Path : CamSpecific_Generic
    {
        public AssetID Unknown_AssetID { get; set; }
        public AssetSingle TimeEnd { get; set; }
        public AssetSingle TimeDelay { get; set; }

        public CamSpecific_Path()
        {
            Unknown_AssetID = 0;
        }
        public CamSpecific_Path(EndianBinaryReader reader)
        {
            Unknown_AssetID = reader.ReadUInt32();
            TimeEnd = reader.ReadSingle();
            TimeDelay = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Unknown_AssetID);
            writer.Write(TimeEnd);
            writer.Write(TimeDelay);
            return writer.ToArray();
        }

        public override bool HasReference(uint assetID) => Unknown_AssetID == assetID;
        public override void Verify(ref List<string> result) => Asset.Verify(Unknown_AssetID, ref result);
    }

    public class CamSpecific_StaticFollow : CamSpecific_Generic
    {
        public AssetSingle RubberBand { get; set; }

        public CamSpecific_StaticFollow() { }
        public CamSpecific_StaticFollow(EndianBinaryReader reader)
        {
            RubberBand = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(RubberBand);
            return writer.ToArray();
        }
    }
}
