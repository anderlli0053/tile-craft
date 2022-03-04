extends Node2D

const Tile = preload("res://sprites/gameScene/Tile.tscn")

var tiles = {}
func _ready():
	tiles["stuff"] = Tile.instance()
	add_child(tiles["stuff"])
	$Camera.current = true

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
