using Noita.SaveToolMancer.Config;
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
            if (IsNoitaRunning())
            {
                return new KeyValuePair<bool, string>(false,"Quit Noita to save the game first!");
            }
            return SaveHelper.CopySaveGame();
        }

        internal static KeyValuePair<bool, string> RestoreSaveGame()
        {
            if (IsNoitaRunning())
            {
                return new KeyValuePair<bool, string>(false, "Quit Noita to restore a game save!");
            }

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

        internal static bool IsNoitaRunning()
        {
            bool isRunning = IsProcessRunning(Statics.GameProcess);
            bool isDevRunning = IsProcessRunning(Statics.DevGameProcess);

            if (isRunning || isDevRunning)
            {
                return true;
            }

            return false;
        }

        static bool IsProcessRunning(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            return processes.Length > 0;
        }
    }

    
}
