using TileCraftUtils;
using TileCraftData;
using Godot;
public class TestCode : Node2D
{
    public override void _Ready()
    {
        WorldData worldData = WorldData.Instance;
        worldData.CreateNewChunk(0);
        worldData.SetBlock(0, 5, BlockData.Data["Dirt"].CharCode);
        GD.Print("start");
        GD.Print(worldData);
        GD.Print("end");
    }
}