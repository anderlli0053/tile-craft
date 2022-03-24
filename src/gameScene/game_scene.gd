extends Node2D

const Tile = preload("res://sprites/gameScene/Tile.tscn")

var tiles = {}
func _ready():
	for x in range(0, 10):
		tiles[x] = Tile.instance()
		tiles[x].set_pos(x, x)
		add_child(tiles[x])
	$Player/Camera.current = true


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
