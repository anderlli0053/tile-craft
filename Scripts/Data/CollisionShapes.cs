using System.Collections.Generic;
using TileCraftUtils;
using Godot;

namespace TileCraftData
{
    public class CollisionShapeData : Dictionary<string, Vector2[]>
    {
        public static readonly CollisionShapeData Data = new FileSystem().ReadCollisionJSON("res://Data/Global/CollisionShapes.json");
    }
}