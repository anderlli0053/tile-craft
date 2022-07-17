using System.Text;
using System.Collections.Generic;
using TileCraftData;
using TileCraftConstants;
using System;
using TileCraftEvents;

namespace TileCraftUtils;

public enum Dimensions
{
    OverWorld,
    Hell,
    VoidLand
}

public enum Layers
{
    Main,
    Background
}
public class WorldData
{
    public static WorldData Instance { get; } = new WorldData();
    private Dictionary<Dimensions, Dictionary<int, GameChunk>> _chunks = new Dictionary<Dimensions, Dictionary<int, GameChunk>>();
    private Dictionary<Dimensions, Dictionary<int, GameChunk>> _generatingChunks = new Dictionary<Dimensions, Dictionary<int, GameChunk>>();
    private WorldData()
    {
        foreach (Dimensions dimension in Enum.GetValues(typeof(Dimensions)))
        {
            _chunks.Add(dimension, new Dictionary<int, GameChunk>());
            _generatingChunks.Add(dimension, new Dictionary<int, GameChunk>());
        }
    }


    public void CreateNewChunk(int chunk, Dimensions dimension = Dimensions.OverWorld, bool generating = true)
    {
        if (generating) _generatingChunks[dimension].Add(chunk, new GameChunk());
        else
        {
            _chunks[dimension].Add(chunk, new GameChunk());
            WorldDataEvents.NewChunkLoad(chunk, dimension);
        }
    }

    public void SetBlock(IntVector position, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true, byte state = 0)
    {
        try
        {
            int chunk = GameChunk.GetChunk(position.x);
            position.x -= chunk * Constants.ChunkSize;
            if (generating) _generatingChunks[dimension][chunk].SetBlock(position, block, state: state);
            else
            {
                _chunks[dimension][chunk].SetBlock(position, block, state: state);
                WorldDataEvents.SetBlock(block, Layers.Main, state, position);
            }

        }
        catch (Exception e)
        {
            throw new ChunkDataNotAvailable("Hmm, chunk hasn't been loaded" + e.StackTrace);
        }
    }

    public void SetBackground(IntVector position, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true, byte state = 0)
    {
        try
        {
            int chunk = GameChunk.GetChunk(position.x);
            position.x -= chunk * Constants.ChunkSize;
            if (generating) _generatingChunks[dimension][chunk].SetBlock(position, block, Layers.Main, state);
            else
            {
                _chunks[dimension][chunk].SetBlock(position, block, Layers.Background, state);
                WorldDataEvents.SetBlock(block, Layers.Background, state, position);
            }
        }
        catch (Exception e)
        {
            throw new ChunkDataNotAvailable("Hmm, chunk hasn't been loaded" + e.StackTrace);
        }
    }
    public void SetBoth(IntVector position, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true)
    {
        SetBackground(position, block, dimension, generating);
        SetBlock(position, block, dimension, generating);
    }
    public void DeleteChunk(int chunk, Dimensions dimension = Dimensions.OverWorld, bool generating = false)
    {
        if (generating) _generatingChunks[dimension].Remove(chunk);
        else
        {
            _chunks[dimension].Remove(chunk);
            WorldDataEvents.ChunkRemove(chunk, dimension);
        }
    }

    public void MoveFinishedChunk(int chunk, Dimensions dimension = Dimensions.OverWorld)
    {
        _chunks[dimension][chunk] = _generatingChunks[dimension][chunk];
        _generatingChunks[dimension].Remove(chunk);
        WorldDataEvents.NewChunkLoad(chunk, dimension);
    }

    public char GetBlock(IntVector position, Layers layer = Layers.Main, Dimensions dimension = Dimensions.OverWorld, bool generating = false)
    {
        int chunk = GameChunk.GetChunk(position.x);
        position.x -= chunk * Constants.ChunkSize;
        return (generating ? _generatingChunks : _chunks)[dimension][chunk].GetBlock(position);
    }

    public byte GetState(IntVector position, Layers layer = Layers.Main, Dimensions dimension = Dimensions.OverWorld, bool generating = false)
    {
        int chunk = GameChunk.GetChunk(position.x);
        position.x -= chunk * Constants.ChunkSize;
        return (generating ? _generatingChunks : _chunks)[dimension][chunk].GetState(position, layer);
    }

    public void SetState(IntVector position, byte state, Layers layer = Layers.Main, Dimensions dimension = Dimensions.OverWorld, bool generating = false)
    {
        int chunk = GameChunk.GetChunk(position.x);
        position.x -= chunk * Constants.ChunkSize;
        (generating ? _generatingChunks : _chunks)[dimension][chunk].SetState(position, state, layer);
        if (!generating){
            WorldDataEvents.SetBlock(GetBlock(position), layer, state, position);
        }
    }

    public bool GetWaterLog(IntVector position, Dimensions dimension = Dimensions.OverWorld, bool generating = false)
    {
        int chunk = GameChunk.GetChunk(position.x);
        position.x -= chunk * Constants.ChunkSize;
        return (generating ? _generatingChunks : _chunks)[dimension][chunk].GetWaterLog(position);
    }

    public void SetWaterLog(IntVector position, bool log, Dimensions dimension = Dimensions.OverWorld, bool generating = false)
    {
        int chunk = GameChunk.GetChunk(position.x);
        position.x -= chunk * Constants.ChunkSize;
        (generating ? _generatingChunks : _chunks)[dimension][chunk].SetWaterLog(position, log);
        if (!generating){
            WorldDataEvents.SetWaterLog(log, position, dimension);
        }
}

    public string ToString(Layers layer = Layers.Main)
    {
        StringBuilder data = new StringBuilder();
        foreach (KeyValuePair<Dimensions, Dictionary<int, GameChunk>> dimension in _chunks)
        {
            data.Append("Dimension ");
            data.AppendLine(dimension.Key.ToString());
            foreach (KeyValuePair<int, GameChunk> chunkList in dimension.Value)
            {
                data.Append("Chunk ");
                data.Append(chunkList.Key.ToString());
                data.Append(": \n");
                data.AppendLine(chunkList.Value.ToString(layer));
            }
        }

        return data.ToString();
    }
}

public class GameChunk
{
    private Dictionary<Layers, char[]> _tileData = new Dictionary<Layers, char[]>();
    private Dictionary<Layers, byte[]> _stateData = new Dictionary<Layers, byte[]>();
    private bool[] _waterLoggedData = new bool[Constants.ChunkSize * Constants.WorldHeight];
    public static int GetChunk(int x)
    {
        return (int)Math.Floor((float)x / Constants.ChunkSize);
    }
    public static int GetIndex(IntVector position)
    {
        return position.x * Constants.ChunkSize + position.y;
    }
    public GameChunk()
    {
        foreach (Layers layer in Enum.GetValues(typeof(Layers)))
        {
            _tileData[layer] = new char[Constants.ChunkSize * Constants.WorldHeight];
            _stateData[layer] = new byte[Constants.ChunkSize * Constants.WorldHeight];
            for (int t = 0; t < _tileData[layer].Length; t++)
            {
                _tileData[layer][t] = BlockData.Data["Air"].CharCode;
                _stateData[layer][t] = 0;
            }
        }
    }

    public void SetBlock(IntVector position, char block, Layers layer = Layers.Main, byte state = 0)
    {
        _tileData[layer][GetIndex(position)] = block;
        _stateData[layer][GetIndex(position)] = state;
    }


    public char GetBlock(IntVector position, Layers layer = Layers.Main)
    {
        return _tileData[layer][GetIndex(position)];
    }

    public void SetState(IntVector position, byte state, Layers layer = Layers.Main)
    {
        _stateData[layer][GetIndex(position)] = state;
    }

    public byte GetState(IntVector position, Layers layer = Layers.Main)
    {
        return _stateData[layer][GetIndex(position)];
    }

    public void SetWaterLog(IntVector position, bool log)
    {
        _waterLoggedData[GetIndex(position)] = log;
    }

    public bool GetWaterLog(IntVector position)
    {
        return _waterLoggedData[GetIndex(position)];
    }

    public string ToString(Layers layer = Layers.Main)
    {
        StringBuilder myString = new StringBuilder();
        int index = 0;
        foreach (char tile in _tileData[layer])
        {
            myString.Append(tile);
            if (++index % Constants.WorldHeight == 0) myString.Append('\n');
        }
        return myString.ToString();
    }
}
