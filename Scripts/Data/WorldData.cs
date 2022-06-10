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

    public enum Layers {
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

        public void SetBlock(int x, int y, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true)
        {
            try
            {
                int chunk = GameChunk.GetChunk(x);
                if (generating) _generatingChunks[dimension][chunk].SetBlock(x - chunk * Constants.ChunkSize, y, block);
                else _chunks[dimension][chunk].SetBlock(x - chunk * Constants.ChunkSize, y, block);
            }
            catch (Exception e)
            {
                throw new ChunkDataNotAvailable("Hmm, chunk hasn't been loaded" + e.StackTrace);
            }
        }

        public void SetBackground(int x, int y, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true)
        {
            try
            {
                int chunk = GameChunk.GetChunk(x);
                if (generating) _generatingChunks[dimension][chunk].SetBlock(x - chunk * Constants.ChunkSize, y, block);
                else _chunks[dimension][chunk].SetBlock(x - chunk * Constants.ChunkSize, y, block, Layers.Background);
            }
            catch (Exception e)
            {
                throw new ChunkDataNotAvailable("Hmm, chunk hasn't been loaded" + e.StackTrace);
            }
        }

        public void SetBoth(int x, int y, char block, Dimensions dimension = Dimensions.OverWorld, bool generating = true){
            SetBackground(x, y, block, dimension, generating);
            SetBlock(x, y, block, dimension, generating);
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

        public char GetBlock(int x, int y, Layers layer = Layers.Main, Dimensions dimension = Dimensions.OverWorld, bool generating=false){
            int chunk = GameChunk.GetChunk(x);
            return (generating ? _generatingChunks:_chunks)[dimension][chunk].GetBlock(x - chunk * Constants.ChunkSize, y);
        }


    public string ToString(Layers layer = Layers.Main)
        {
            StringBuilder data = new StringBuilder();
            foreach (KeyValuePair<Dimensions, Dictionary<int, GameChunk>> dimension in _generatingChunks)
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
        private Dictionary<Layers, char[]> _data = new Dictionary<Layers, char[]>();
        public static int GetChunk(int x)
        {
            return (int)Math.Floor((float)x / Constants.ChunkSize);
        }
        public GameChunk()
        {
            foreach (Layers layer in Enum.GetValues(typeof(Layers)))
            {
                _data[layer] = new char[Constants.ChunkSize * Constants.WorldHeight];
                for (int t = 0; t < _data[layer].Length; t++) {
                    _data[layer][t] = BlockData.Data["Air"].CharCode;
                }
            }
        }

        public void SetBlock(int x, int y, char block, Layers layer = Layers.Main)
        {
            _data[layer][x*Constants.ChunkSize+y] = block;
        }

        public char GetBlock(int x, int y, Layers layer = Layers.Main){
            return _data[layer][x * Constants.ChunkSize + y];
        }

        public string ToString(Layers layer = Layers.Main)
        {
            StringBuilder myString = new StringBuilder();
            int index = 0;
            foreach (char tile in _data[layer])
            {
                myString.Append(tile);
                if (++index % Constants.WorldHeight == 0) myString.Append('\n');
            }
            return myString.ToString();
        }
    }
}