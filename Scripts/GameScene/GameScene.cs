using Godot;
using Thread = System.Threading.Thread;
using TileCraftThreads;
using System.Threading;
using TileCraftConstants;
using TileCraftUtils;

namespace TileCraftMain
{
    public class GameScene : Control
    {
        ResizeHandler resizeHandler = new ResizeHandler();
        public Node2D WorldContainer;
        public bool Generating = true;
        public Tile[] TileArray = new Tile[60000];

        public override void _Ready()
        {
            base._Ready();
            WorldContainer = GetNode<Node2D>("World");
        }

        public void GenerateTiles()
        {
        }

        public void OnResize()
        {
            resizeHandler.NoBlanks(WorldContainer, new Vector2(Constants.TileContainerWidth, Constants.TileContainerHeight));
        }
        public override void _Process(float delta)
        {
            base._Process(delta);
            OnResize();
        }
    }

}
