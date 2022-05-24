using System;
namespace TileCraftConstants
{
    public class Constants
    {
        public static readonly int TileSize = 64;
        public static readonly float Gravity = 9.81f * TileSize;
        public static readonly float PlayerSpeedDamp = .7f;
        public static readonly float PlayerJumpSpeed = (float)Math.Sqrt((double)2 * Gravity * 2 * TileSize) * 64;
        public static readonly float PlayerAcceleration = (3 * TileSize * TileSize) / (PlayerSpeedDamp / (1f - PlayerSpeedDamp));
        public static readonly byte ChunkSize = 16;
        public static readonly short WorldHeight = 500;
        public static readonly short WindowWidth = 1280;
        public static readonly short WindowHeight = 720;
        public static readonly short TileContainerWidth = 1536;
        public static readonly short TileContainerHeight = 1152;

    }
}