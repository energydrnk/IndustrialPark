﻿using HipHopFile;
using RenderWareFile;
using SharpDX;
using System.ComponentModel;
using System.Linq;

namespace IndustrialPark
{
    public class AssetJSP_INFO : Asset
    {
        private const string categoryName = "JSP Info";

        public int renderWareVersion;

        [Category(categoryName)]
        public AssetID[] JSP_AssetIDs { get; set; }

        [Category(categoryName)]
        public Platform Platform { get; set; }

        [Category(categoryName), TypeConverter(typeof(ExpandableObjectConverter))]
        public CollisionData_Section1_00BEEF01 Section1 { get; set; }
        [Category(categoryName), TypeConverter(typeof(ExpandableObjectConverter))]
        public CollisionData_Section2_00BEEF02 Section2 { get; set; }
        [Category(categoryName), TypeConverter(typeof(ExpandableObjectConverter))]
        public GenericSection Section2_Data { get; set; }
        [Category(categoryName), TypeConverter(typeof(ExpandableObjectConverter))]
        public CollisionData_Section3_00BEEF03 Section3 { get; set; }
        [Category(categoryName), TypeConverter(typeof(ExpandableObjectConverter))]
        public CollisionData_Section4_00BEEF04 Section4 { get; set; }

        public AssetJSP_INFO(Section_AHDR AHDR, Game game, Platform platform, AssetJSP[] jspAssets) : base(AHDR, game)
        {
            Platform = platform;
            JSP_AssetIDs = jspAssets.Select(j => (AssetID)j.assetID).ToArray();

            using (var reader = new EndianBinaryReader(AHDR.data, Endianness.Little))
            {
                Section1 = new CollisionData_Section1_00BEEF01(reader, platform);

                renderWareVersion = Section1.RenderWareVersion;

                Section2 = new CollisionData_Section2_00BEEF02(reader, platform);
                int done = 0;
                foreach (AssetJSP jsp in jspAssets.Reverse())
                {
                    xJSPNodeInfo[] entries = new xJSPNodeInfo[jsp.AtomicFlags.Length];
                    for (int i = 0; i < entries.Length; i++)
                        entries[i] = Section2.jspNodeList[done + i];
                    done += entries.Length;
                    ArchiveEditorFunctions.AddToJspNodeInfo(jsp.assetID, entries.Reverse().ToArray());
                }

                if (game == Game.BFBB && Platform == Platform.GameCube)
                {
                    Section3 = new CollisionData_Section3_00BEEF03(reader);
                }

                if (game != Game.BFBB)
                {
                    Section4 = new CollisionData_Section4_00BEEF04(reader);
                }
            }
        }

        public AssetJSP_INFO(string assetName, Game game, Platform platform) : base(assetName, AssetType.JSPInfo)
        {
            _game = game;
            Platform = platform;
        }

        public override void SetDynamicProperties(DynamicTypeDescriptor dt)
        {

            if (game == Game.BFBB)
            {
                dt.RemoveProperty("Section2_Data");
                dt.RemoveProperty("Section4");
                if (Platform != Platform.GameCube)
                    dt.RemoveProperty("Section3");
            }

            if (game != Game.BFBB)
            {
                dt.RemoveProperty("Section2");
                dt.RemoveProperty("Section3");
            }
        }

        public override void Serialize(EndianBinaryWriter writer)
        {
            Section1.RenderWareVersion = renderWareVersion;
            Section1.Serialize(writer);
            Section2.RenderWareVersion = renderWareVersion;
            Section2.Serialize(writer);

            if (game == Game.BFBB && Platform == Platform.GameCube)
            {
                Section3.RenderWareVersion = renderWareVersion;
                Section3.Serialize(writer);
            }

            if (game != Game.BFBB)
                Section4.Serialize(writer);
        }

        public void ApplyScale(Vector3 factor)
        {
            for (int i = 0; i < Section1.branchNodes.Length; i++)
            {
                switch (Section1.branchNodes[i].LeftDirection)
                {
                    case ClumpDirection.X:
                        Section1.branchNodes[i].LeftValue *= factor.X;
                        Section1.branchNodes[i].RightValue *= factor.X;
                        break;
                    case ClumpDirection.Y:
                        Section1.branchNodes[i].LeftValue *= factor.Y;
                        Section1.branchNodes[i].RightValue *= factor.Y;
                        break;
                    default:
                        Section1.branchNodes[i].LeftValue *= factor.Z;
                        Section1.branchNodes[i].RightValue *= factor.Z;
                        break;
                }
            }

            for (int i = 0; i < Section3.vertexList.Length; i++)
            {
                Section3.vertexList[i].X *= factor.X;
                Section3.vertexList[i].Y *= factor.Y;
                Section3.vertexList[i].Z *= factor.Z;
            }
        }

        public void CreateFromJsp(AssetJSP assetJSP)
        {
            JSP_AssetIDs = new AssetID[] { assetJSP.assetID };

            var clump = assetJSP.GetClump();
            renderWareVersion = clump.renderWareVersion;

            Section1 = new CollisionData_Section1_00BEEF01(Platform);

            Section2 = new CollisionData_Section2_00BEEF02(Platform);

            Section2_Data = null;

            Section3 = new CollisionData_Section3_00BEEF03(clump.geometryList.geometryList);

            Section4 = null;
        }

        public override bool HasReference(uint assetID)
        {
            return JSP_AssetIDs.Contains(assetID);
        }
    }
}