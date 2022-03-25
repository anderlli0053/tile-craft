class_name Tile extends StaticBody2D

const BLOCK_SHAPES = preload("res://src/utils/shapes.gd")
var BLOCK_DATA = preload("res://src/utils/block_data.gd").new().BLOCK_DATA

var file = File.new()

func _ready():
	change_block("grass") # Replace with function body.

func change_block(block:String):
	$Texture.play(block)
	$Collider.polygon = BLOCK_SHAPES[BLOCK_DATA[block]["collision"]]
	
	
func set_pos(x:int, y:int):
	set_global_position(Vector2(x*64, -y*64))

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
