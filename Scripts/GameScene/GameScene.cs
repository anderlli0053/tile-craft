using Godot;
using System;

public class GameScene : Node2D
{
    
    private Tile[] tiles = new Tile[10];
    public override void _Ready()
    {
        for (int n = 0; n < 10; n++)
        {
            tiles[n] = new Tile();
            tiles[n].SetPosition(0, n);
            AddChild(tiles[n]);
        }
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
