using Godot;
namespace TileCraftThreads
{
    public class CreateTileThread
    {
        public static void Job(object raw)
        {
            GameScene gameScene = (GameScene) raw;
            Node2D container =  gameScene.WorldContainer;
            Tile[] tileArray = gameScene.TileArray;
            for (int i = 0; i < 60000; i++)
            {
                tileArray[i] = Tile.CreateNew();
                tileArray[i].SetPosition(i, 0);
                tileArray[i].SetBlock("Grass");
                container.AddChild(tileArray[i]);
            }
        }
    }
}
