using TileCraftData;
using Godot;
using TileCraftUtils;
public class TestCode : Node2D
{
    public override void _Ready()
    {
        WorldData data = WorldData.Instance;
        data.CreateNewChunk(0);
        data.SetBlock(new IntVector(0, 6), BlockData.Data["Dirt"].CharCode);
        data.MoveFinishedChunk(0);
        GD.Print(data.ToString());
        
    }
}