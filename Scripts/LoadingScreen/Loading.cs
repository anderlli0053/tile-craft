using Godot;
using TileCraftUtils;
using TileCraftConstants;
using System;

public class Loading : Node2D
{
    private Control _background;
    public override void _Ready()
    {
        base._Ready();
        _background = GetNode<ColorRect>("Background");
    }

    public override void _Process(float delta)
    {
        _background.RectScale = ResizeHandler.NoBlanks(new Vector2(Constants.WindowWidth, Constants.WindowHeight));
    }
}
