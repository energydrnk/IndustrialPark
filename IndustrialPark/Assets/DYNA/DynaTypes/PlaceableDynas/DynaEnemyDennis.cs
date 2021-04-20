﻿using HipHopFile;
using System.Collections.Generic;
using System.ComponentModel;

namespace IndustrialPark
{
    public enum EnemyDennisType : uint
    {
        dennis_junk_bind = 0xCB1BBC20,
        dennis_hoff_bind = 0x3D6C5895
    }

    public class DynaEnemyDennis : DynaEnemySB
    {
        private const string dynaCategoryName = "Enemy:SB:Dennis";

        protected override int constVersion => 3;

        [Category(dynaCategoryName)]
        public EnemyDennisType DennisType
        {
            get => (EnemyDennisType)(uint)Model_AssetID;
            set => Model_AssetID = (uint)value;
        }
        [Category(dynaCategoryName)]
        public AssetID Unknown50 { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown54 { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown58 { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown5C { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown60 { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown64 { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown68 { get; set; }
        [Category(dynaCategoryName)]
        public AssetID Unknown6C { get; set; }

        public DynaEnemyDennis(Section_AHDR AHDR, Game game, Platform platform) : base(AHDR, DynaType.Enemy__SB__Dennis, game, platform)
        {
            var reader = new EndianBinaryReader(AHDR.data, platform);
            reader.BaseStream.Position = entityDynaEndPosition;

            Unknown50 = reader.ReadUInt32();
            Unknown54 = reader.ReadUInt32();
            Unknown58 = reader.ReadUInt32();
            Unknown5C = reader.ReadUInt32();
            Unknown60 = reader.ReadUInt32();
            Unknown64 = reader.ReadUInt32();
            Unknown68 = reader.ReadUInt32();
            Unknown6C = reader.ReadUInt32();
        }

        protected override byte[] SerializeDyna(Game game, Platform platform)
        {
            var writer = new EndianBinaryWriter(platform);
            writer.Write(SerializeEntityDyna(platform));

            writer.Write(Unknown50);
            writer.Write(Unknown54);
            writer.Write(Unknown58);
            writer.Write(Unknown5C);
            writer.Write(Unknown60);
            writer.Write(Unknown64);
            writer.Write(Unknown68);
            writer.Write(Unknown6C);

            return writer.ToArray();
        }

        public override bool HasReference(uint assetID)
        {
            if (Unknown50 == assetID)
                return true;
            if (Unknown54 == assetID)
                return true;
            if (Unknown58 == assetID)
                return true;
            if (Unknown5C == assetID)
                return true;
            if (Unknown60 == assetID)
                return true;
            if (Unknown64 == assetID)
                return true;
            if (Unknown68 == assetID)
                return true;
            if (Unknown6C == assetID)
                return true;

            return base.HasReference(assetID);
        }

        public override void Verify(ref List<string> result)
        {
            base.Verify(ref result);
            
            Verify(Unknown50, ref result);
            Verify(Unknown54, ref result);
            Verify(Unknown58, ref result);
            Verify(Unknown5C, ref result);
            Verify(Unknown60, ref result);
            Verify(Unknown64, ref result);
            Verify(Unknown68, ref result);
            Verify(Unknown6C, ref result);
        }
    }
}