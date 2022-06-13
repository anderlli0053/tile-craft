using Godot;
using TileCraftUtils;

namespace TileCraftEvents {
    public class Events {
        [Signal]
        public delegate void NewChunkLoadedEvent(int chunk, Dimensions dimension);

        [Signal]
        public delegate void ChunkRemovedEvent(int chunk, Dimensions dimension);
    }
}