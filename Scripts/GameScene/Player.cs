using Godot;
using TileCraftConstants;

namespace TileCraftMain;

public class Player : KinematicBody2D
{
    public Vector2 Velocity = Vector2.Zero;
    public override void _Ready()
    {
        Position = new Vector2(0, Constants.TileSize * -3);
    }

    public override void _PhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("go_left"))
        {
            Velocity.x -= Constants.PlayerAcceleration * delta;
        }
        if (Input.IsActionPressed("go_right"))
        {
            Velocity.x += Constants.PlayerAcceleration * delta;
        }
        if (Input.IsActionPressed("jump"))
        {
            if (IsOnFloor())
            {
                Velocity.y = Constants.PlayerJumpSpeed * -delta;
            }
        }

        Velocity.x *= Constants.PlayerSpeedDamp;
        Velocity.y += Constants.Gravity * delta;
        MoveAndSlide(Velocity, Vector2.Up);
    }
}
