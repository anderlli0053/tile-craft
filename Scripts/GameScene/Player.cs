using Godot;
using GameConstants;
using System;

public class Player : KinematicBody2D
{
    public Vector2 Velocity = Vector2.Zero;
    public override void _Ready()
    {
        Position = new Vector2(2, Constants.TileSize * -3);
    }

    public override void _Process(float delta)
    {
        Velocity.y += delta * Constants.Gravity;
        MoveAndSlide(Velocity);
    }
}
