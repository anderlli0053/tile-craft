using Godot;
using System;


public class GameScene : Node2D
{
    public Node2D WorldContainer;
    private Tile[] _tiles = new Tile[30];
    public override void _Ready()
    {
        base._Ready();
        GenerateTiles();
    }

    public void GenerateTiles(){
        WorldContainer = GetNode<Node2D>("World");
        for (int i = 0; i < 15; i++)
        {
            _tiles[i] = Tile.CreateNew();
            _tiles[i].SetPosition(i, 0);
            _tiles[i].SetBlock("Grass");
            WorldContainer.AddChild(_tiles[i]);
        }
        for (int i = 15; i < 30; i++)
        {
            _tiles[i] = Tile.CreateNew();
            _tiles[i].SetPosition(i, 1);
            _tiles[i].SetBlock("Air");
            WorldContainer.AddChild(_tiles[i]);
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
