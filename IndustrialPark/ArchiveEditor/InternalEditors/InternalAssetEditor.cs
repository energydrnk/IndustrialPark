﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static IndustrialPark.Models.BSP_IO_Shared;
using static IndustrialPark.Models.BSP_IO_CreateBSP;
using static IndustrialPark.Models.Model_IO_Assimp;
using System.IO;
using RenderWareFile;
using IndustrialPark.Models;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace IndustrialPark
{
    public partial class InternalAssetEditor : Form, IInternalEditor
    {
        public InternalAssetEditor(Asset asset, ArchiveEditorFunctions archive, bool hideHelp)
        {
            InitializeComponent();
            TopMost = true;

            this.asset = asset;
            this.archive = archive;

            DynamicTypeDescriptor dt = new DynamicTypeDescriptor(asset.GetType());
            asset.SetDynamicProperties(dt);
            propertyGridAsset.SelectedObject = dt.FromComponent(asset);
            
            labelAssetName.Text = $"[{asset.AHDR.assetType.ToString()}] {asset.ToString()}";

            propertyGridAsset.HelpVisible = !hideHelp;

            if (asset is AssetCAM cam) SetupForCam(cam);
            else if (asset is AssetCSN csn) SetupForCsn(csn);
            else if (asset is AssetGRUP grup) SetupForGrup(grup);
            else if (asset is AssetRenderWareModel arwm) SetupForModel(arwm);
            else if (asset is AssetSHRP shrp) SetupForShrp(shrp);
            else if (asset is AssetWIRE wire) SetupForWire(wire);
            
            Button buttonHelp = new Button() { Dock = DockStyle.Fill, Text = "Open Wiki Page", AutoSize = true };
            buttonHelp.Click += (object sender, EventArgs e) =>
                System.Diagnostics.Process.Start(AboutBox.WikiLink + asset.AHDR.assetType.ToString());
            tableLayoutPanel1.Controls.Add(buttonHelp, 0, tableLayoutPanel1.RowCount - 1);

            Button buttonFindCallers = new Button() { Dock = DockStyle.Fill, Text = "Find Who Targets Me", AutoSize = true };
            buttonFindCallers.Click += (object sender, EventArgs e) =>
                Program.MainForm.FindWhoTargets(GetAssetID());
            tableLayoutPanel1.Controls.Add(buttonFindCallers, 1, tableLayoutPanel1.RowCount - 1);
        }

        private void InternalAssetEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            archive.CloseInternalEditor(this);
        }

        private Asset asset;
        private ArchiveEditorFunctions archive;

        public uint GetAssetID()
        {
            return asset.AHDR.assetID;
        }
        
        public void RefreshPropertyGrid()
        {
            propertyGridAsset.Refresh();
        }

        private void propertyGridAsset_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            archive.UnsavedChanges = true;
            propertyGridAsset.Refresh();
        }
        
        public void SetHideHelp(bool hideHelp)
        {
            propertyGridAsset.HelpVisible = !hideHelp;
        }

        private void AddRow()
        {
            tableLayoutPanel1.RowCount += 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        }

        private void SetupForCam(AssetCAM asset)
        {
            AddRow();
            
            Button buttonGetPos = new Button() { Dock = DockStyle.Fill, Text = "Get View Position", AutoSize = true };
            buttonGetPos.Click += (object sender, EventArgs e) =>
            {
                asset.SetPosition(Program.MainForm.renderer.Camera.Position);

                propertyGridAsset.Refresh();
                archive.UnsavedChanges = true;
            };
            tableLayoutPanel1.Controls.Add(buttonGetPos);

            Button buttonGetDir = new Button() { Dock = DockStyle.Fill, Text = "Get View Direction", AutoSize = true };
            buttonGetDir.Click += (object sender, EventArgs e) =>
            {
                asset.SetNormalizedForward(Program.MainForm.renderer.Camera.Forward);
                asset.SetNormalizedUp(Program.MainForm.renderer.Camera.Up);
                asset.SetNormalizedLeft(Program.MainForm.renderer.Camera.Right);

                propertyGridAsset.Refresh();
                archive.UnsavedChanges = true;
            };
            tableLayoutPanel1.Controls.Add(buttonGetDir);
        }

        private void SetupForGrup(AssetGRUP asset)
        {
            AddRow();

            Button buttonAddSelected = new Button() { Dock = DockStyle.Fill, Text = "Add Selected To Group", AutoSize = true };
            buttonAddSelected.Click += (object sender, EventArgs e) =>
            {
                List<AssetID> items = new List<AssetID>();
                foreach (uint i in asset.GroupItems)
                    items.Add(i);
                foreach (uint i in archive.GetCurrentlySelectedAssetIDs())
                    if (!items.Contains(i))
                        items.Add(i);
                asset.GroupItems = items.ToArray();

                propertyGridAsset.Refresh();
                archive.UnsavedChanges = true;
            };
            tableLayoutPanel1.Controls.Add(buttonAddSelected);
            tableLayoutPanel1.SetColumnSpan(buttonAddSelected, 2);
        }

        private void SetupForCsn(AssetCSN asset)
        {
            AddRow();

            Button buttonExportModlsAnims = new Button() { Dock = DockStyle.Fill, Text = "Export All MODL/ANIM", AutoSize = true };
            buttonExportModlsAnims.Click += (object sender, EventArgs e) =>
            {
                CommonOpenFileDialog saveFile = new CommonOpenFileDialog()
                {
                    IsFolderPicker = true,
                };

                if (saveFile.ShowDialog() == CommonFileDialogResult.Ok)
                    asset.ExtractToFolder(saveFile.FileName);
            };
            tableLayoutPanel1.Controls.Add(buttonExportModlsAnims);
            tableLayoutPanel1.SetColumnSpan(buttonExportModlsAnims, 2);
        }

        private void SetupForModel(AssetRenderWareModel asset)
        {
            AddRow();
            AddRow();
            AddRow();

            CheckBox ignoreMeshColors = new CheckBox() { Dock = DockStyle.Fill, Text = "Ignore Mesh Colors", AutoSize = true };
            ignoreMeshColors.Checked = true;
            tableLayoutPanel1.Controls.Add(ignoreMeshColors, 0, 2);
            CheckBox flipUVs = new CheckBox() { Dock = DockStyle.Fill, Text = "Flip UVs", AutoSize = true };
            tableLayoutPanel1.Controls.Add(flipUVs, 0, 3);

            Button buttonImport = new Button() { Dock = DockStyle.Fill, Text = "Import", AutoSize = true };
            buttonImport.Click += (object sender, EventArgs e) =>
            {
                OpenFileDialog openFile = new OpenFileDialog()
                {
                    Filter = GetImportFilter(), // "All supported types|*.dae;*.obj;*.bsp|DAE Files|*.dae|OBJ Files|*.obj|BSP Files|*.bsp|All files|*.*",
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    asset.Data = Path.GetExtension(openFile.FileName).ToLower().Equals(".dff") ? File.ReadAllBytes(openFile.FileName) :
                        ReadFileMethods.ExportRenderWareFile(CreateDFFFromAssimp(openFile.FileName, false, true), modelRenderWareVersion(asset.game));

                    asset.Setup(Program.MainForm.renderer);

                    archive.UnsavedChanges = true;
                }
            };
            tableLayoutPanel1.Controls.Add(buttonImport, 0, 4);

            CheckBox exportTextures = new CheckBox() { Dock = DockStyle.Fill, Text = "Export Textures", AutoSize = true };
            tableLayoutPanel1.Controls.Add(exportTextures, 1, 3);

            Button buttonExport = new Button() { Dock = DockStyle.Fill, Text = "Export", AutoSize = true };
            buttonExport.Click += (object sender, EventArgs e) =>
            {
                ChooseTarget.GetTarget(out bool success, out Assimp.ExportFormatDescription format, out string textureExtension);

                if (success)
                {
                    SaveFileDialog a = new SaveFileDialog()
                    {
                        Filter = format == null ? "RenderWare BSP|*.bsp" : format.Description + "|*." + format.FileExtension,
                    };

                    if (a.ShowDialog() == DialogResult.OK)
                    {
                        if (format == null)
                            File.WriteAllBytes(a.FileName, asset.Data);
                        else if (format.FileExtension.ToLower().Equals("obj") && asset.AHDR.assetType == HipHopFile.AssetType.BSP)
                            ConvertBSPtoOBJ(a.FileName, ReadFileMethods.ReadRenderWareFile(asset.Data), true);
                        else
                            ExportAssimp(Path.ChangeExtension(a.FileName, format.FileExtension), ReadFileMethods.ReadRenderWareFile(asset.Data), true, format, textureExtension);

                        if (exportTextures.Checked)
                        {
                            string folderName = Path.GetDirectoryName(a.FileName);
                            var bitmaps = archive.GetTexturesAsBitmaps(asset.Textures);
                            ReadFileMethods.treatStuffAsByteArray = false;
                            foreach (string textureName in bitmaps.Keys)
                                bitmaps[textureName].Save(folderName + "/" + textureName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                        }
                    }
                }
            };
            tableLayoutPanel1.Controls.Add(buttonExport, 1, 4);

            if (asset.IsNativeData)
            {
                buttonExport.Enabled = false;
                exportTextures.Enabled = false;
            }
        }

        private void SetupForShrp(AssetSHRP asset)
        {
            AddRow();
            AddRow();
            AddRow();

            foreach (var i in new int[] { 3, 4, 5, 6, 8, 9 })
            {
                Button buttonAdd = new Button() { Dock = DockStyle.Fill, Text = $"Add Type {i}", AutoSize = true };
                buttonAdd.Click += (object sender, EventArgs e) =>
                {
                    asset.AddEntry(i);
                    propertyGridAsset.Refresh();
                    archive.UnsavedChanges = true;
                };
                tableLayoutPanel1.Controls.Add(buttonAdd);
            }
        }

        private void SetupForWire(AssetWIRE asset)
        {
            AddRow();
            
            Button buttonImport = new Button() { Dock = DockStyle.Fill, Text = "Import", AutoSize = true };
            buttonImport.Click += (object sender, EventArgs e) =>
            {
                OpenFileDialog openFile = new OpenFileDialog()
                {
                    Filter = "OBJ Files|*.obj|All files|*.*",
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    asset.FromObj(openFile.FileName);
                    archive.UnsavedChanges = true;
                }
            };
            tableLayoutPanel1.Controls.Add(buttonImport);
            
            Button buttonExport = new Button() { Dock = DockStyle.Fill, Text = "Export", AutoSize = true };
            buttonExport.Click += (object sender, EventArgs e) =>
            {
                SaveFileDialog saveFile = new SaveFileDialog()
                {
                    Filter = "OBJ Files|*.obj|All files|*.*",
                };

                if (saveFile.ShowDialog() == DialogResult.OK)
                    asset.ToObj(saveFile.FileName);
            };
            tableLayoutPanel1.Controls.Add(buttonExport);
        }
    }
}
