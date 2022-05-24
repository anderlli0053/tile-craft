using System.Collections.Generic;
using TileCraftUtils;
namespace TileCraftData
{
    public class BlockData : Dictionary<string, TileData>
    {
        public static readonly BlockData Data = new FileSystem().ReadJSON<BlockData>("res://Data/GameScene/Tiles/BlockData.json");
    }
}