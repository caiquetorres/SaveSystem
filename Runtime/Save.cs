using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace SaveSystem
{
    public static partial class SaveSystem
    {
        public static void Save<TValue>(TValue data)
            where TValue : class
        {
            SaveSystemHelpers.CreateGameDataFolder();

            var fileName = SaveSystemHelpers.CreateFileName(typeof(TValue));
            var binaryFormatter = new BinaryFormatter();
            var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var file = File.Create(filePath))
            {
                var json = JsonUtility.ToJson(data);
                binaryFormatter.Serialize(file, json);
            }
        }

        public static void Save<TValue>(string fileName, TValue data)
            where TValue : class
        {
            SaveSystemHelpers.CreateGameDataFolder();

            var binaryFormatter = new BinaryFormatter();
            var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var file = File.Create(filePath))
            {
                var json = JsonUtility.ToJson(data);
                binaryFormatter.Serialize(file, json);
            }
        }

        public static async Task SaveAsync<TValue>(TValue data)
            where TValue : class
        {
            await Task.Run(() =>
            {
                SaveSystemHelpers.CreateGameDataFolder();

                var fileName = SaveSystemHelpers.CreateFileName(typeof(TValue));
                var binaryFormatter = new BinaryFormatter();
                var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                using (var file = File.Create(filePath))
                {
                    var json = JsonUtility.ToJson(data);
                    binaryFormatter.Serialize(file, json);
                }
            });
        }

        public static async Task SaveAsync<TValue>(string fileName, TValue data)
            where TValue : class
        {
            await Task.Run(() =>
            {
                SaveSystemHelpers.CreateGameDataFolder();

                var binaryFormatter = new BinaryFormatter();
                var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

                if (File.Exists(filePath))
                    File.Delete(filePath);

                using (var file = File.Create(filePath))
                {
                    var json = JsonUtility.ToJson(data);
                    binaryFormatter.Serialize(file, json);
                }
            });
        }
    }
}
