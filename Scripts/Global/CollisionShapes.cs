using System.Collections.Generic;
using Newtonsoft.Json;
using Godot;
namespace TileCraftData
{
    public class CollisionShapeData : Dictionary<string, Vector2[]>
    {
        public static readonly CollisionShapeData data = CollisionShapeData.LoadCollisionShapeData();
        private static CollisionShapeData LoadCollisionShapeData()
        {
            File fs = new File();
            fs.Open("res://Data/Global/CollisionShapes.json", File.ModeFlags.Read);
            string data = fs.GetAsText();
            Dictionary<string, int[][]> obj = JsonConvert.DeserializeObject<Dictionary<string, int[][]>>(data);
            CollisionShapeData finalObj = new CollisionShapeData();
            foreach (string item in obj.Keys)
            {
                int vecNum = obj[item].Length;
                finalObj.Add(item, new Vector2[vecNum]);
                for (int vecIndex = 0; vecIndex < vecNum; vecIndex++)
                {
                    Vector2 vec = finalObj[item][vecIndex];
                    finalObj[item][vecIndex] = new Vector2(vec.x, vec.y);
                }
            }
            return finalObj;
        }
    }
}