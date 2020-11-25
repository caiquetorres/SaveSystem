using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SaveSystem
{
    public static class SaveSystemHelpers
    {
        public static readonly string FolderPath = string.Concat(Application.persistentDataPath, "/gameData/");

        public static void CreateGameDataFolder()
        {
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);
        }

        public static void ResetGameData()
        {
            if (!Directory.Exists(FolderPath))
                Directory.Delete(FolderPath, true);
        }

        public static string CreateFileName(Type type) => type.ToString().Split('.').Last();
    }
}
