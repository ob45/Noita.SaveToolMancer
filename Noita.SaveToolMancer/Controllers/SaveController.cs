using Noita.SaveToolMancer.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Noita.SaveToolMancer.Controllers
{
    internal class SaveController
    {
        internal static KeyValuePair<bool, string> BackupSaveGame()
        {
            return SaveHelper.CopySaveGame();
        }

        internal static KeyValuePair<bool, string> RestoreSaveGame()
        {
            return SaveHelper.RestoreSaveGame();
        }

        internal static KeyValuePair<bool, string> OpenGameFolder()
        {
            string userName = Environment.UserName;
            string noitaPath = $@"C:\Users\{userName}\AppData\LocalLow\Nolla_Games_Noita";

            if (Directory.Exists(noitaPath))
            {
                Process.Start("explorer.exe", noitaPath);
            }
            else
            {
                return new KeyValuePair<bool, string>(false, "Save Game folder not found!");
            }

                
            return new KeyValuePair<bool, string> (true, string.Empty);
        }

    }
}
