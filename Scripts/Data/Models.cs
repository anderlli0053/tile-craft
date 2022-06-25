using System;
namespace TileCraftData
{
    public class TileData
    {
        public char CharCode;
        public string Main;
        public string Overlay;
        public string Collision = "FullSquare";
        public float Bounciness = 0f;
        public float Friction;
    }
    public class Biome {
        public int MaxHeight;
        public int MinHeight;
        public float NoiseStep;
    }
    public class ChunkDataNotAvailable : Exception
    {
        public ChunkDataNotAvailable() { }
        public ChunkDataNotAvailable(string message) : base(message) { }
        public ChunkDataNotAvailable(string message, Exception inner) : base(message, inner) { }
        public ChunkDataNotAvailable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class GameSettings {
        public bool SeenAd;
    }

    public struct IntVector{
        public int x;
        public int y;
        public IntVector(int x = 0, int y = 0){
            this.x = x;
            this.y = y;
        }
        
    }
}