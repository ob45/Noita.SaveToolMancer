using Noita.SaveToolMancer.Config;
using System;
using System.Collections.Generic;
using System.IO;

namespace Noita.SaveToolMancer.Helpers
{
    internal class SaveHelper
    {
        internal static KeyValuePair<bool, string> CopySaveGame()
        {

            try
            {
                string userName = Environment.UserName;
                string noitaPath = $@"C:\Users\{userName}\AppData\LocalLow\" + Statics.GameFolderName;
                string savePath = Path.Combine(noitaPath, Statics.DefaultSaveName);
                string backupPath = Path.Combine(noitaPath, Statics.DefaultSaveName + "-Backup");

                // If save game doesn't exist = error
                if (!Directory.Exists(savePath))
                {
                    return new KeyValuePair<bool, string>(false, "Save folder not found.");
                }

                // If a backup already exists, overwrite it
                if (Directory.Exists(backupPath))
                {
                    Directory.Delete(backupPath, true);
                }

                CopyDirectory(savePath, backupPath);

                return new KeyValuePair<bool, string>(true, "Backup created successfully.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, $"Error: {ex.Message}");
            }
        }

        private static void CopyDirectory(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            // Copy all directories
            foreach (string folder in Directory.GetDirectories(sourceDir))
            {
                string destFolder = Path.Combine(destDir, Path.GetFileName(folder));
                CopyDirectory(folder, destFolder);
            }

            // Copy all files
            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

        }

        internal static KeyValuePair<bool, string> RestoreSaveGame()
        {
            try
            {
                string userName = Environment.UserName;
                string noitaPath = $@"C:\Users\{userName}\AppData\LocalLow\Nolla_Games_Noita";
                string savePath = Path.Combine(noitaPath, Statics.DefaultSaveName);
                string backupPath = Path.Combine(noitaPath, Statics.DefaultSaveName + "-Backup");

                if (!Directory.Exists(backupPath))
                {
                    return new KeyValuePair<bool, string>(false, "Backup folder not found.");
                }

                // Delete existing (current) save00 if it exists
                if (Directory.Exists(savePath))
                {
                    Directory.Delete(savePath, true);
                }

                // Restore save00 from backup
                CopyDirectory(backupPath, savePath);

                return new KeyValuePair<bool, string>(true, "Save restored successfully.");
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, $"Error: {ex.Message}");
            }
        }

    }
}
