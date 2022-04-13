using Godot;
using TileCraftData;
using Newtonsoft.Json;

public class Tile : StaticBody2D
{
    private readonly BlockData BLOCK_DATA = BlockData.Data;
    private readonly CollisionShapeData SHAPE_DATA = CollisionShapeData.Data;
    public CollisionPolygon2D Collider;
    public AnimatedSprite BackgroundMain;
    public AnimatedSprite BackgroundOverlay;
    public AnimatedSprite MainMain;
    public AnimatedSprite MainOverlay;

    public override void _Ready()
    {
        base._Ready();
        Collider = GetNode<CollisionPolygon2D>("Collider");
        BackgroundMain = GetNode<AnimatedSprite>("Background");
        BackgroundOverlay = GetNode<AnimatedSprite>("Background/Overlay");
        MainMain = GetNode<AnimatedSprite>("Main");
        MainOverlay = GetNode<AnimatedSprite>("Main/Overlay");
        Collider.Polygon = SHAPE_DATA["FullSquare"];
        SetBlock("Grass");
    }

    public void SetBlock(string block, bool main = true)
    {
        if (main)
        {
            MainMain.Animation = BLOCK_DATA[block].Main;
            MainOverlay.Animation = BLOCK_DATA[block].Overlay;
            Collider.Polygon = SHAPE_DATA[BLOCK_DATA[block].Collision];
        }
        else
        {
            BackgroundMain.Animation = BLOCK_DATA[block].Main;
            BackgroundOverlay.Animation = BLOCK_DATA[block].Overlay;
        }
    }

    public void SetPosition(int x, int y)
    {
        Position = new Vector2(x * 64, y * 64);
    }
}