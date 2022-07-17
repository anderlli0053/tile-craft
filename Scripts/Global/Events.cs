using System.Numerics;
using TileCraftUtils;
using TileCraftData;

namespace TileCraftEvents;

public class WorldDataEvents
{
    public delegate void NewChunkLoadedDelegate(int chunk, Dimensions dimension);
    public static event NewChunkLoadedDelegate NewChunkLoadedEvent;
    public delegate void ChunkRemovedDelegate(int chunk, Dimensions dimension);
    public static event ChunkRemovedDelegate ChunkRemovedEvent;
    public delegate void SetBlockDelegate(char block, Layers layer, byte state, IntVector position);
    public static event SetBlockDelegate SetBlockEvent;
    public delegate void SetWaterLogDelegate(bool log, IntVector position, Dimensions dimension);
    public static event SetWaterLogDelegate SetWaterLogEvent;

    public static void NewChunkLoad(int chunk, Dimensions dimension){
        NewChunkLoadedEvent?.Invoke(chunk, dimension);
    }
    public static void ChunkRemove(int chunk, Dimensions dimension){
        ChunkRemovedEvent?.Invoke(chunk, dimension);
    }
    
    public static void SetBlock(char block, Layers layer, byte state, IntVector position){
        SetBlockEvent?.Invoke(block, layer, state, position);
    }

    public static void SetWaterLog(bool log, IntVector position, Dimensions dimension){
        SetWaterLogEvent?.Invoke(log, position, dimension);
    }
}
