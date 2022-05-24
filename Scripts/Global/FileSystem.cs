using Godot;
using Newtonsoft.Json;
using TileCraftData;
using System.Collections.Generic;
namespace TileCraftUtils
{
    public class FileSystem
    {
        private File _fs = new File();

        public T ReadJSON<T>(string location) where T : new()
        {
            if (!_fs.FileExists(location)) return new T();
            _fs.Open(location, File.ModeFlags.Read);
            return JsonConvert.DeserializeObject<T>(_fs.GetAsText());
        }

        public CollisionShapeData ReadCollisionJSON(string location){
            Dictionary<string, int[][]> obj = ReadJSON<Dictionary<string, int[][]>>(location);
            CollisionShapeData finalObj = new CollisionShapeData();
            foreach (string item in obj.Keys)
            {
                int vecNum = obj[item].Length;
                finalObj.Add(item, new Vector2[vecNum]);
                for (int vecIndex = 0; vecIndex < vecNum; vecIndex++)
                {
                    int[] vec = obj[item][vecIndex];
                    finalObj[item][vecIndex] = new Vector2(vec[0], vec[1]);
                }
            }
            return finalObj;
        }
        public void WriteJSON(string location, string data){
            _fs.Open(location, File.ModeFlags.Write);
            _fs.StoreString(data);
        }

        public void Close(){
            _fs.Close();
        }
    }
}

