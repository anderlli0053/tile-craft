using Godot;
using TileCraftData;
using Newtonsoft.Json;

public class Tile : StaticBody2D
{
    private readonly BlockData BlockData = BlockData.Data;
    private readonly CollisionShapeData ShapeData = CollisionShapeData.Data;
    public static PackedScene SceneObject = GD.Load<PackedScene>("res://Sprites/GameScene/Tile.tscn");
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
        Collider.Polygon = ShapeData["FullSquare"];
        GD.Print(ShapeData["FullSquare"]);
        SetBlock("Grass");
    }

    public void SetBlock(string block, bool main = true)
    {
        if (main)
        {
            MainMain.Animation = BlockData[block].Main;
            MainOverlay.Animation = BlockData[block].Overlay;
            Collider.Polygon = ShapeData[BlockData[block].Collision];
        }
        else
        {
            BackgroundMain.Animation = BlockData[block].Main;
            BackgroundOverlay.Animation = BlockData[block].Overlay;
        }
    }

    public void SetPosition(int x, int y)
    {
        Position = new Vector2(x * 64, y * 64);
    }

    public static Tile CreateNew()
    {
        return SceneObject.Instance<Tile>();
    }
}