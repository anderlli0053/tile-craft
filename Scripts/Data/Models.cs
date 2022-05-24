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
        public float Friction = 1f;
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
}