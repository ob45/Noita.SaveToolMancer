using Noita.SaveToolMancer.Helpers;
using System.Collections.Generic;

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

    }
}
