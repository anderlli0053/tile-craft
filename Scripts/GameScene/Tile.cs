using Godot;
using TileCraftData;
using Newtonsoft.Json;

public class Tile : StaticBody2D
{
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
        GD.Print(JsonConvert.SerializeObject(CollisionShapeData.data));
    }
}