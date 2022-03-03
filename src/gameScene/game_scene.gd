extends Node2D

const Tile = preload("res://sprites/gameScene/Tile.tscn")
const Resizer = preload("res://src/global/resize.gd")

var tiles = {}
func _ready():
	tiles["stuff"] = Tile.instance()
	add_child(tiles["stuff"])
	$Camera.current = true

func _on_resize():
	Resizer._on_resize()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
