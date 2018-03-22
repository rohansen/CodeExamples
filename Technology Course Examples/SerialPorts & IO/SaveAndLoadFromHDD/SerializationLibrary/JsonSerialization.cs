using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationLibrary
{
    public static class JsonSerialization
    {
        private static string saveDirectory = "./";
        private static string fileName = "saved_{0}.json";
        private static JsonSerializerSettings serializerSettings;
        static JsonSerialization()
        {
            serializerSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        }
        /// <summary>
        /// Serializes an object, and stores it on the HDD 
        /// note: objects are stored on HDD in file: saved_{TYPENAME}.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        public static void SerializeAndSave<T>(this T input)
        {
            string currentFileName = string.Format(fileName, typeof(T).Name);
            if (!File.Exists(currentFileName))
                File.Create(currentFileName).Close();
            string json = JsonConvert.SerializeObject(input, Formatting.None, serializerSettings);
            using (StreamWriter stream = new StreamWriter(saveDirectory + currentFileName, true))
            {
                stream.WriteLine(json);
                stream.Close();
            }
        }
        /// <summary>
        /// Deserializes a json object to a single object of type T
        /// note: objects are stored on HDD in file: saved_{TYPENAME}.json
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize into</typeparam>
        /// <param name="json">json string containing one object of type T</param>
        /// <returns></returns>
        public static T DeSerializeSingleOrDefault<T>(string json)
        {
            var obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
        /// <summary>
        /// Deserializes all json objects into the given type
        /// note: objects are stored on HDD in file: saved_{TYPENAME}.json
        /// </summary>
        /// <typeparam name="T">Type of objects to fetch from HDD</typeparam>
        /// <returns></returns>
        public static IEnumerable<T> DeSerializeAndLoadAll<T>()
        {
            string currentFileName = string.Format(fileName, typeof(T).Name);
            if (!File.Exists(currentFileName))
                return null;
            List<T> deserializedObjects = new List<T>();
            using (StreamReader stream = new StreamReader(saveDirectory + currentFileName))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    var obj = JsonConvert.DeserializeObject<T>(line);
                    deserializedObjects.Add(obj);
                }
                stream.Close();
            }
            return deserializedObjects;
        }
    }
}
