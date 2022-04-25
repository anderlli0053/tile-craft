using Godot;
using System;


public class GameScene : Node2D
{
    public Node2D WorldContainer;
    public override void _Ready()
    {
        WorldContainer = GetNode<Node2D>("World");

        WorldContainer.AddChild(Tile.CreateNew());
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
