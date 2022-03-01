class_name Tile extends StaticBody2D

func _ready():
	pass # Replace with function body.

func change_block(block:String):
	$Texture.play(block)

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
