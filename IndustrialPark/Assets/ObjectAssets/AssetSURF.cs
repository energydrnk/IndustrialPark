﻿using HipHopFile;
using System.Collections.Generic;
using System.ComponentModel;

namespace IndustrialPark
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class zSurfMatFX : GenericAssetDataContainer
    {
        public FlagBitmask Flags { get; set; } = IntFlagsDescriptor();
        public AssetID BumpMapTexture_AssetID { get; set; }
        public AssetID EnvMapTexture_AssetID { get; set; }
        public AssetSingle Shininess { get; set; }
        public AssetSingle Bumpiness { get; set; }
        public AssetID DualMapTexture_AssetID { get; set; }

        public zSurfMatFX() { }
        public zSurfMatFX(EndianBinaryReader reader)
        {
            Flags.FlagValueInt = reader.ReadUInt32();
            BumpMapTexture_AssetID = reader.ReadUInt32();
            EnvMapTexture_AssetID = reader.ReadUInt32();
            Shininess = reader.ReadSingle();
            Bumpiness = reader.ReadSingle();
            DualMapTexture_AssetID = reader.ReadUInt32();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Flags.FlagValueInt);
            writer.Write(BumpMapTexture_AssetID);
            writer.Write(EnvMapTexture_AssetID);
            writer.Write(Shininess);
            writer.Write(Bumpiness);
            writer.Write(DualMapTexture_AssetID);
            return writer.ToArray();
        }

        public override bool HasReference(uint assetID) =>
            BumpMapTexture_AssetID == assetID ||
            EnvMapTexture_AssetID == assetID ||
            DualMapTexture_AssetID == assetID;

        public override void Verify(ref List<string> result)
        {
            Verify(BumpMapTexture_AssetID, ref result);
            Verify(EnvMapTexture_AssetID, ref result);
            Verify(DualMapTexture_AssetID, ref result);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class zSurfColorFX : GenericAssetDataContainer
    {
        public FlagBitmask Flags { get; set; } = ShortFlagsDescriptor();
        public short Mode { get; set; }
        public AssetSingle Speed { get; set; }

        public zSurfColorFX() { }
        public zSurfColorFX(EndianBinaryReader reader)
        {
            Flags.FlagValueShort = reader.ReadUInt16();
            Mode = reader.ReadInt16();
            Speed = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Flags.FlagValueShort);
            writer.Write(Mode);
            writer.Write(Speed);
            return writer.ToArray();
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class zSurfTextureAnim : GenericAssetDataContainer
    {
        public short Padding { get; set; }
        public short Mode { get; set; }
        public AssetID Group_AssetID { get; set; }
        public AssetSingle Speed { get; set; }

        public zSurfTextureAnim() { }
        public zSurfTextureAnim(EndianBinaryReader reader)
        {
            Padding = reader.ReadInt16();
            Mode = reader.ReadInt16();
            Group_AssetID = reader.ReadUInt32();
            Speed = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Padding);
            writer.Write(Mode);
            writer.Write(Group_AssetID);
            writer.Write(Speed);
            return writer.ToArray();
        }

        public override bool HasReference(uint assetID) => Group_AssetID == assetID;
        public override void Verify(ref List<string> result) => Verify(Group_AssetID, ref result);
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class zSurfUVFX : GenericAssetDataContainer
    {
        public int Mode { get; set; }
        public AssetSingle Rot { get; set; }
        public AssetSingle RotSpd { get; set; }
        public AssetSingle Trans_X { get; set; }
        public AssetSingle Trans_Y { get; set; }
        public AssetSingle Trans_Z { get; set; }
        public AssetSingle TransSpeed_X { get; set; }
        public AssetSingle TransSpeed_Y { get; set; }
        public AssetSingle TransSpeed_Z { get; set; }
        public AssetSingle Scale_X { get; set; }
        public AssetSingle Scale_Y { get; set; }
        public AssetSingle Scale_Z { get; set; }
        public AssetSingle ScaleSpeed_X { get; set; }
        public AssetSingle ScaleSpeed_Y { get; set; }
        public AssetSingle ScaleSpeed_Z { get; set; }
        public AssetSingle Min_X { get; set; }
        public AssetSingle Min_Y { get; set; }
        public AssetSingle Min_Z { get; set; }
        public AssetSingle Max_X { get; set; }
        public AssetSingle Max_Y { get; set; }
        public AssetSingle Max_Z { get; set; }
        public AssetSingle MinMaxSpeed_X { get; set; }
        public AssetSingle MinMaxSpeed_Y { get; set; }
        public AssetSingle MinMaxSpeed_Z { get; set; }

        public zSurfUVFX() { }
        public zSurfUVFX(EndianBinaryReader reader)
        {
            Mode = reader.ReadInt32();
            Rot = reader.ReadSingle();
            RotSpd = reader.ReadSingle();
            Trans_X = reader.ReadSingle();
            Trans_Y = reader.ReadSingle();
            Trans_Z = reader.ReadSingle();
            TransSpeed_X = reader.ReadSingle();
            TransSpeed_Y = reader.ReadSingle();
            TransSpeed_Z = reader.ReadSingle();
            Scale_X = reader.ReadSingle();
            Scale_Y = reader.ReadSingle();
            Scale_Z = reader.ReadSingle();
            ScaleSpeed_X = reader.ReadSingle();
            ScaleSpeed_Y = reader.ReadSingle();
            ScaleSpeed_Z = reader.ReadSingle();
            Min_X = reader.ReadSingle();
            Min_Y = reader.ReadSingle();
            Min_Z = reader.ReadSingle();
            Max_X = reader.ReadSingle();
            Max_Y = reader.ReadSingle();
            Max_Z = reader.ReadSingle();
            MinMaxSpeed_X = reader.ReadSingle();
            MinMaxSpeed_Y = reader.ReadSingle();
            MinMaxSpeed_Z = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(Mode);
            writer.Write(Rot);
            writer.Write(RotSpd);
            writer.Write(Trans_X);
            writer.Write(Trans_Y);
            writer.Write(Trans_Z);
            writer.Write(TransSpeed_X);
            writer.Write(TransSpeed_Y);
            writer.Write(TransSpeed_Z);
            writer.Write(Scale_X);
            writer.Write(Scale_Y);
            writer.Write(Scale_Z);
            writer.Write(ScaleSpeed_X);
            writer.Write(ScaleSpeed_Y);
            writer.Write(ScaleSpeed_Z);
            writer.Write(Min_X);
            writer.Write(Min_Y);
            writer.Write(Min_Z);
            writer.Write(Max_X);
            writer.Write(Max_Y);
            writer.Write(Max_Z);
            writer.Write(MinMaxSpeed_X);
            writer.Write(MinMaxSpeed_Y);
            writer.Write(MinMaxSpeed_Z);
            return writer.ToArray();
        }
    }

    public class AssetSURF : BaseAsset
    {
        private const string categoryName = "Surface";

        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte DamageType { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte Sticky { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte DamageFlags { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte SurfaceType { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte Phys_Pad { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte SlideStart { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte SlideStop { get; set; }
        [Category(categoryName)]
        public FlagBitmask PhysicsFlags { get; set; } = ByteFlagsDescriptor(
            "Slide Off Player",
            "Angle Player",
            null,
            "No Stand",
            "Out Of Bounds",
            "No Stand 2",
            "Ledge Grab");
        [Category(categoryName)]
        public AssetSingle Friction { get; set; }
        [Category(categoryName)]
        public zSurfMatFX zSurfMatFX { get; set; }
        [Category(categoryName)]
        public zSurfColorFX zSurfColorFX { get; set; }
        [Category(categoryName)]
        public FlagBitmask TextureAnimFlags { get; set; } = IntFlagsDescriptor();
        [Category(categoryName)]
        public zSurfTextureAnim zSurfTextureAnim1 { get; set; }
        [Category(categoryName)]
        public zSurfTextureAnim zSurfTextureAnim2 { get; set; }
        [Category(categoryName)]
        public FlagBitmask UVEffectsFlags { get; set; } = IntFlagsDescriptor();
        [Category(categoryName)]
        public zSurfUVFX zSurfUVFX { get; set; }
        [Category(categoryName)]
        public zSurfUVFX zSurfUVFX2 { get; set; }
        [Category(categoryName), TypeConverter(typeof(HexByteTypeConverter))]
        public byte On { get; set; }
        [Category(categoryName)]
        public AssetSingle OutOfBoundsDelay { get; set; }
        [Category(categoryName)]
        public AssetSingle WalljumpScaleXZ { get; set; }
        [Category(categoryName)]
        public AssetSingle WalljumpScaleY { get; set; }
        [Category(categoryName)]
        public AssetSingle DamageTimer { get; set; }
        [Category(categoryName)]
        public AssetSingle DamageBounce { get; set; }

        public AssetSURF(string assetName) : base(assetName, AssetType.SURF, BaseAssetType.Surface)
        {
            zSurfMatFX = new zSurfMatFX();
            zSurfColorFX = new zSurfColorFX();
            zSurfTextureAnim1 = new zSurfTextureAnim();
            zSurfTextureAnim2 = new zSurfTextureAnim();
            zSurfUVFX = new zSurfUVFX();
            zSurfUVFX2 = new zSurfUVFX();
        }

        public AssetSURF(Section_AHDR AHDR, Game game, Platform platform) : base(AHDR, game, platform)
        {
            var reader = new EndianBinaryReader(AHDR.data, platform);
            reader.BaseStream.Position = baseHeaderEndPosition;

            DamageType = reader.ReadByte();
            Sticky = reader.ReadByte();
            DamageFlags = reader.ReadByte();
            SurfaceType = reader.ReadByte();
            Phys_Pad = reader.ReadByte();
            SlideStart = reader.ReadByte();
            SlideStop = reader.ReadByte();
            PhysicsFlags.FlagValueByte = reader.ReadByte();
            Friction = reader.ReadSingle();
            zSurfMatFX = new zSurfMatFX(reader);
            zSurfColorFX = new zSurfColorFX(reader);
            TextureAnimFlags.FlagValueInt = reader.ReadUInt32();
            zSurfTextureAnim1 = new zSurfTextureAnim(reader);
            zSurfTextureAnim2 = new zSurfTextureAnim(reader);
            UVEffectsFlags.FlagValueInt = reader.ReadUInt32();
            zSurfUVFX = new zSurfUVFX(reader);

            if (game != Game.Scooby)
            {
                zSurfUVFX2 = new zSurfUVFX(reader);
                On = reader.ReadByte();
                reader.ReadByte();
                reader.ReadByte();
                reader.ReadByte();
            }
            else zSurfUVFX2 = null;

            OutOfBoundsDelay = reader.ReadSingle();
            WalljumpScaleXZ = reader.ReadSingle();
            WalljumpScaleY = reader.ReadSingle();
            DamageTimer = reader.ReadSingle();
            DamageBounce = reader.ReadSingle();
        }

        public override byte[] Serialize(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(SerializeBase(platform));

            writer.Write(DamageType);
            writer.Write(Sticky);
            writer.Write(DamageFlags);
            writer.Write(SurfaceType);
            writer.Write(Phys_Pad);
            writer.Write(SlideStart);
            writer.Write(SlideStop);
            writer.Write(PhysicsFlags.FlagValueByte);
            writer.Write(Friction);
            writer.Write(zSurfMatFX.Serialize(game, platform));
            writer.Write(zSurfColorFX.Serialize(game, platform));
            writer.Write(TextureAnimFlags.FlagValueInt);
            writer.Write(zSurfTextureAnim1.Serialize(game, platform));
            writer.Write(zSurfTextureAnim2.Serialize(game, platform));
            writer.Write(UVEffectsFlags.FlagValueInt);
            writer.Write(zSurfUVFX.Serialize(game, platform));
            if (game != Game.Scooby)
            {
                writer.Write(zSurfUVFX2.Serialize(game, platform));
                writer.Write(On);
                writer.Write((byte)0);
                writer.Write((byte)0);
                writer.Write((byte)0);
            }
            writer.Write(OutOfBoundsDelay);
            writer.Write(WalljumpScaleXZ);
            writer.Write(WalljumpScaleY);
            writer.Write(DamageTimer);
            writer.Write(DamageBounce);

            writer.Write(SerializeLinks(platform));
            return writer.ToArray();
        }

        public override bool HasReference(uint assetID) =>
            zSurfMatFX.HasReference(assetID) ||
            zSurfColorFX.HasReference(assetID) ||
            zSurfTextureAnim1.HasReference(assetID) ||
            zSurfTextureAnim2.HasReference(assetID) ||
            base.HasReference(assetID);

        public override void Verify(ref List<string> result)
        {
            base.Verify(ref result);
            zSurfMatFX.Verify(ref result);
            zSurfColorFX.Verify(ref result);
            zSurfTextureAnim1.Verify(ref result);
            zSurfTextureAnim2.Verify(ref result);
        }
    }
}