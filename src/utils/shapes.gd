extends Node2D

const FULL_SQUARE = PoolVector2Array([
    Vector2(-32, -32), 
    Vector2(32, -32), 
    Vector2(32, 32), 
    Vector2(-32, 32)
])
const LEFT_BOTTOM_STAIRS = PoolVector2Array([
    Vector2(-32, -32), 
    Vector2(-32, 32), 
    Vector2(32, 32), 
    Vector2(32, 0), 
    Vector2(0, 0),
    Vector2(0, -32), 
])