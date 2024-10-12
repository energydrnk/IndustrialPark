﻿using HipHopFile;
using RenderWareFile;
using RenderWareFile.Sections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HipHopFile.Functions;

namespace IndustrialPark
{
    public static class TextureIOHelper
    {
        public static readonly object locker = new object();

        public static string txdGenFolder => Application.StartupPath + "/Resources/txdgen_1.0/";
        public static string tempGcTxdsDir => txdGenFolder + "Temp/txds_gc/";
        public static string tempPcTxdsDir => txdGenFolder + "Temp/txds_pc/";
        public static string pathToGcTXD => tempGcTxdsDir + "temp.txd";
        public static string pathToPcTXD => tempPcTxdsDir + "temp.txd";

        public static void PerformTXDConversionExternal(Platform targetPlatform, bool toPC = true, bool compress = false, bool generateMipmaps = false, string custom_output = null)
        {
            lock (locker)
            {
                if (!converterInitialized)
                    initConverter();

                string ini =
                    "[Main]\r\n" +
                    (custom_output ?? (toPC ?
                    "gameRoot=" + tempGcTxdsDir + "\r\n" +
                    "outputRoot=" + tempPcTxdsDir + "\r\n" +
                    "targetVersion=VC\r\n" +
                    "targetPlatform=PC\r\n"
                    :
                    "gameRoot=" + tempPcTxdsDir + "\r\n" +
                    "outputRoot=" + tempGcTxdsDir + "\r\n" +
                    "targetVersion=VC\r\n" +
                    "targetPlatform=" +
                    (targetPlatform == Platform.GameCube ? "Gamecube" :
                    targetPlatform == Platform.Xbox ? "XBOX" :
                    targetPlatform == Platform.PS2 ? "PS2" : "PC")
                    + "\r\n")) +
                    "clearMipmaps=false\r\n" +
                    "generateMipmaps=" + generateMipmaps.ToString().ToLower() + "\r\n" +
                    "mipGenMode=default\r\n" +
                    "mipGenMaxLevel=10\r\n" +
                    "improveFiltering=true\r\n" +
                    "compressTextures=" + compress.ToString().ToLower() + "\r\n" +
                    "compressionQuality=1.0\r\n" +
                    "palRuntimeType=PNGQUANT\r\n" +
                    "dxtRuntimeType=SQUISH\r\n" +
                    "warningLevel=0\r\n" +
                    "ignoreSecureWarnings=true\r\n" +
                    "reconstructIMGArchives=false\r\n" +
                    "fixIncompatibleRasters=true\r\n" +
                    "dxtPackedDecompression=false\r\n" +
                    "imgArchivesCompressed=false\r\n" +
                    "ignoreSerializationRegions=true";

                File.WriteAllText(txdGenFolder + "txdgen.ini", ini);

                txdgenProcess.Start();
                txdgenProcess.WaitForExit(5000);
            }
        }

        private static Process txdgenProcess;
        private static bool converterInitialized = false;

        public static void initConverter()
        {
            txdgenProcess = new Process();
            txdgenProcess.StartInfo.FileName = txdGenFolder + "txdgen.exe";
            txdgenProcess.StartInfo.WorkingDirectory = txdGenFolder;
            txdgenProcess.StartInfo.CreateNoWindow = true;
            txdgenProcess.StartInfo.RedirectStandardOutput = true;
            txdgenProcess.StartInfo.RedirectStandardError = true;
            txdgenProcess.StartInfo.UseShellExecute = false;
            txdgenProcess.EnableRaisingEvents = true;
            converterInitialized = true;
        }

        public static void closeConverter()
        {
            if (converterInitialized && txdgenProcess != null && !txdgenProcess.HasExited)
                txdgenProcess.Kill();
        }

        public static int currentTextureVersion(Game game, Platform platform)
        {
            switch (game)
            {
                case Game.Scooby when platform == Platform.PS2:
                    return 0x00000310; // 3.1.0.0
                case Game.Scooby when platform == Platform.GameCube:
                    return 0x0C02FFFF; // 3.3.0.2
                case Game.BFBB when platform == Platform.GameCube:
                    return 0x1003FFFF; // 3.4.0.3
                case Game.Scooby when platform == Platform.Xbox:
                    return 0x1005FFFF; // 3.4.0.5
                case Game.BFBB:
                case Game.Incredibles when platform == Platform.PS2:
                    return 0x1400FFFF; // 3.5.0.0
                default:
                    return 0x1C02000A; // 3.7.0.2-A
            }
        }

        public static void ExportSingleTextureToRWTEX(byte[] data, string fileName)
        {
            ReadFileMethods.treatStuffAsByteArray = true;

            foreach (RWSection rw in ReadFileMethods.ReadRenderWareFile(data))
                if (rw is TextureDictionary_0016 td)
                    foreach (TextureNative_0015 tn in td.textureNativeList)
                        File.WriteAllBytes(fileName, ReadFileMethods.ExportRenderWareFile(tn, tn.renderWareVersion));

            ReadFileMethods.treatStuffAsByteArray = false;
        }

        public static void ExportSingleTextureToDictionary(string fileName, byte[] data, string textureName)
        {
            ReadFileMethods.treatStuffAsByteArray = true;

            List<TextureNative_0015> textNativeList = new List<TextureNative_0015>();

            int fileVersion = 0;

            foreach (RWSection rw in ReadFileMethods.ReadRenderWareFile(data))
                if (rw is TextureDictionary_0016 td)
                    foreach (TextureNative_0015 tn in td.textureNativeList)
                    {
                        fileVersion = tn.renderWareVersion;
                        tn.textureNativeStruct.textureName = textureName.Replace(".RW3", "");
                        textNativeList.Add(tn);
                    }

            TextureDictionary_0016 rws = new TextureDictionary_0016()
            {
                textureDictionaryStruct = new TextureDictionaryStruct_0001()
                {
                    textureCount = (short)textNativeList.Count(),
                    unknown = 0
                },
                textureNativeList = textNativeList,
                textureDictionaryExtension = new Extension_0003()
                {
                    extensionSectionList = new List<RWSection>()
                }
            };

            rws.textureNativeList = rws.textureNativeList.OrderBy(f => f.textureNativeStruct.textureName).ToList();

            File.WriteAllBytes(fileName, ReadFileMethods.ExportRenderWareFile(rws, fileVersion));

            ReadFileMethods.treatStuffAsByteArray = false;

        }

        public static Section_AHDR CreateRWTXFromBitmap(Game game, Platform platform, string fileName, bool appendRW3, bool flip, bool mipmaps, bool compress, bool transFix)
        {
            return CreateRWTXsFromBitmaps(game, platform, new List<string>() { fileName }, appendRW3, flip, mipmaps, compress, transFix)[0];
        }

        public static List<Section_AHDR> CreateRWTXsFromBitmaps
            (Game game, Platform platform, List<string> fileNames, bool appendRW3, bool flip, bool mipmaps, bool compress, bool transFix)
        {
            lock (locker)
            {
                if (transFix)
                    compress = false;

                List<TextureNative_0015> textureNativeList = new List<TextureNative_0015>();

                foreach (string fileName in fileNames)
                {
                    string textureName = Path.GetFileNameWithoutExtension(fileName);
                    Bitmap bitmap = new Bitmap(fileName);

                    List<byte> bitmapData = new List<byte>(bitmap.Width * bitmap.Height * 4);

                    if (flip)
                        bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    for (int j = 0; j < bitmap.Height; j++)
                        for (int i = 0; i < bitmap.Width; i++)
                        {
                            bitmapData.Add(bitmap.GetPixel(i, j).B);
                            bitmapData.Add(bitmap.GetPixel(i, j).G);
                            bitmapData.Add(bitmap.GetPixel(i, j).R);
                            bitmapData.Add(bitmap.GetPixel(i, j).A);
                        }

                    textureNativeList.Add(
                        new TextureNative_0015()
                        {
                            textureNativeStruct = new TextureNativeStruct_0001()
                            {
                                textureName = textureName + (appendRW3 ? ".RW3" : ""),
                                alphaName = "",
                                height = (short)bitmap.Height,
                                width = (short)bitmap.Width,
                                mipMapCount = 1,
                                addressModeU = TextureAddressMode.TEXTUREADDRESSWRAP,
                                addressModeV = TextureAddressMode.TEXTUREADDRESSWRAP,
                                filterMode = TextureFilterMode.FILTERLINEAR,
                                bitDepth = 32,
                                platformType = TexturePlatformID.PCD3D8,
                                compression = 0,
                                hasAlpha = false,
                                rasterFormatFlags = TextureRasterFormat.RASTER_C8888,
                                type = 4,
                                mipMaps = new MipMapEntry[] { new MipMapEntry(bitmapData.Count, bitmapData.ToArray()) },
                            },
                            textureNativeExtension = new Extension_0003()
                        }
                    );

                    bitmap.Dispose();
                }

                if (!Directory.Exists(tempPcTxdsDir))
                    Directory.CreateDirectory(tempPcTxdsDir);
                if (!Directory.Exists(tempGcTxdsDir))
                    Directory.CreateDirectory(tempGcTxdsDir);

                File.WriteAllBytes(pathToPcTXD, ReadFileMethods.ExportRenderWareFile(new TextureDictionary_0016()
                {
                    textureDictionaryStruct = new TextureDictionaryStruct_0001() { textureCount = (short)textureNativeList.Count, unknown = 0 },
                    textureNativeList = textureNativeList,
                    textureDictionaryExtension = new Extension_0003()
                }, currentTextureVersion(game, platform)));

                PerformTXDConversionExternal(platform, false, compress, mipmaps);

                ReadFileMethods.treatStuffAsByteArray = true;

                List<Section_AHDR> AHDRs = new List<Section_AHDR>();

                foreach (TextureNative_0015 texture in ((TextureDictionary_0016)ReadFileMethods.ReadRenderWareFile(pathToGcTXD)[0]).textureNativeList)
                    AHDRs.Add(new Section_AHDR(BKDRHash(texture.textureNativeStruct.textureName), AssetType.Texture, ArchiveEditorFunctions.AHDRFlagsFromAssetType(AssetType.Texture),
                        new Section_ADBG(0, texture.textureNativeStruct.textureName, "", 0),
                        ReadFileMethods.ExportRenderWareFile(new TextureDictionary_0016()
                        {
                            textureDictionaryStruct = new TextureDictionaryStruct_0001() { textureCount = 1, unknown = 0 },
                            textureNativeList = new List<TextureNative_0015>() { texture },
                            textureDictionaryExtension = new Extension_0003()
                        }, currentTextureVersion(game, platform))));

                // fix for apparent transparency issue
                if (transFix && platform == Platform.GameCube)
                    foreach (var AHDR in AHDRs)
                        AHDR.data[0x9B] = 0x01;

                ReadFileMethods.treatStuffAsByteArray = false;

                File.Delete(pathToGcTXD);
                File.Delete(pathToPcTXD);

                return AHDRs;
            }
        }

        public static void FixTextureForScooby(ref byte[] data)
        {
            for (int j = 0x6D; j < 0x8C; j++)
                data[j] = 0xCD;
        }
    }
}