using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CoworkingApp.Data
{
    public class JsonManager<T>
    {
        public List<T> GetCollection()
        {
            string collectionPath = $@"{Directory.GetCurrentDirectory()}/{typeof(T)}.json";
            List<T> myCollection = new List<T>();
            if (File.Exists(collectionPath))
            {
                var streamReader = new StreamReader(collectionPath);
                var currentContent = streamReader.ReadToEnd();
                myCollection = JsonConvert.DeserializeObject<List<T>>(currentContent);
                streamReader.Close();
            }
            else
            {
                var jsonCollection = JsonConvert.SerializeObject(myCollection, Formatting.Indented);
                var streamWriter = new StreamWriter(collectionPath);
                streamWriter.Write(jsonCollection);
                streamWriter.Close();
            }
            return myCollection;
        }

        public bool SaveCollection(List<T> collection)
        {
            string collectionPath = $@"{Directory.GetCurrentDirectory()}/{typeof(T)}.json";
            try
            {
                var jsonCollection = JsonConvert.SerializeObject(collection, Formatting.Indented);
                var streamWriter = new StreamWriter(collectionPath);
                streamWriter.Write(jsonCollection);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
