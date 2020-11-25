using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace SaveSystem
{
    public static partial class SaveSystem
    {
        public static TValue Load<TValue>()
            where TValue : class
        {
            var fileName = SaveSystemHelpers.CreateFileName(typeof(TValue));
            var binaryFormatter = new BinaryFormatter();
            var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

            using (var file = File.Open(filePath, FileMode.Open))
            {
                return JsonUtility.FromJson<TValue>((string) binaryFormatter.Deserialize(file));
            }
        }

        public static TValue Load<TValue>(string fileName)
            where TValue : class
        {
            var binaryFormatter = new BinaryFormatter();
            var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

            using (var file = File.Open(filePath, FileMode.Open))
            {
                return JsonUtility.FromJson<TValue>((string) binaryFormatter.Deserialize(file));
            }
        }

        public static async Task<TValue> LoadAsync<TValue>()
            where TValue : class
        {
            return await Task.Run(() =>
            {
                var fileName = SaveSystemHelpers.CreateFileName(typeof(TValue));
                var binaryFormatter = new BinaryFormatter();
                var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

                using (var file = File.Open(filePath, FileMode.Open))
                {
                    return JsonUtility.FromJson<TValue>((string) binaryFormatter.Deserialize(file));
                }
            });
        }

        public static async Task<TValue> LoadAsync<TValue>(string fileName)
            where TValue : class
        {
            return await Task.Run(() =>
            {
                var binaryFormatter = new BinaryFormatter();
                var filePath = string.Concat(SaveSystemHelpers.FolderPath, fileName);

                using (var file = File.Open(filePath, FileMode.Open))
                {
                    return JsonUtility.FromJson<TValue>((string) binaryFormatter.Deserialize(file));
                }
            });
        }
    }
}
