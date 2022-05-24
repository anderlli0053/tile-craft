
using System.Collections.Generic;
using TileCraftData;
using TileCraftConstants;
using System;

namespace TileCraftUtils
{
    public class WorldData
    {
        public static WorldData Instance { get; } = new WorldData();
        private WorldData() { }

        private Dictionary<int, GameChunk> _chunks = new Dictionary<int, GameChunk>();
        public void CreateNewChunk(int index)
        {
            _chunks.Add(index, new GameChunk());
        }

        public void SetBlock(int x, int y, char block)
        {
            try
            {
                int chunk = (int)Math.Floor((float)x / Constants.ChunkSize);
                _chunks[chunk].SetBlock(x - chunk * Constants.ChunkSize, y, block);
            }
            catch (Exception e)
            {
                throw new ChunkDataNotAvailable("Hmm, chunk hasn't been loaded" + e.StackTrace);
            }
        }
    }

    public class GameChunk
    {
        private char[][] _data = new char[Constants.ChunkSize][];
        public GameChunk()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] = new char[Constants.WorldHeight];
            }
        }

        public void SetBlock(int x, int y, char block)
        {
            _data[x][y] = block;
        }
    }
}