using Microsoft.Win32.SafeHandles;
using Godot;
using System.Text;
using System.Collections.Generic;
using TileCraftData;
using TileCraftConstants;
using System;

namespace TileCraftUtils
{
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


        public void CreateNewChunk(int index, Dimensions dimension = Dimensions.OverWorld, bool generating = true)
        {
            if (generating) _generatingChunks[dimension].Add(index, new GameChunk());
            else _chunks[dimension].Add(index, new GameChunk());
        }

        public void SetBlock(IntVector position, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true, byte state = 0)
        {
            try
            {
                int chunk = GameChunk.GetChunk(position.x);
                position.x -= chunk * Constants.ChunkSize;
                if (generating) _generatingChunks[dimension][chunk].SetBlock(position, block, state: state);
                else _chunks[dimension][chunk].SetBlock(position, block, state: state);
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
                else _chunks[dimension][chunk].SetBlock(position, block, Layers.Background, state);
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
            else _chunks[dimension].Remove(chunk);
        }

        public void MoveFinishedChunk(int chunk, Dimensions dimension = Dimensions.OverWorld)
        {
            _chunks[dimension][chunk] = _generatingChunks[dimension][chunk];
            _generatingChunks[dimension].Remove(chunk);
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
            return (generating ? _generatingChunks : _chunks)[dimension][chunk].GetState(position);
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
        public static int GetChunk(int x)
        {
            return (int)Math.Floor((float)x / Constants.ChunkSize);
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
            _tileData[layer][position.x * Constants.ChunkSize + position.y] = block;
            _stateData[layer][position.x * Constants.ChunkSize + position.y] = state;
        }

        public char GetBlock(IntVector position, Layers layer = Layers.Main)
        {
            return _tileData[layer][position.x * Constants.ChunkSize + position.y];
        }

        public byte GetState(IntVector position, Layers layer = Layers.Main)
        {
            return _stateData[layer][position.x * Constants.ChunkSize + position.
            y];
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
}