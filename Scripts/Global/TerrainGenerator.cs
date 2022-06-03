using TileCraftData;
using Godot;

public class TerrainGenerator
{
    public int _seed;
    private OpenSimplexNoise _noise;
    public static TerrainGenerator Instance { get; private set; } = new TerrainGenerator();
    private TerrainGenerator(int seed = 0)
    {
        _noise = new OpenSimplexNoise();
        _noise.Seed = seed;
    }
    public TerrainGenerator SetNewNoise(int seed)
    {
        return (Instance = new TerrainGenerator(seed));
    }
    
}