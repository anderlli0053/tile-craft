extends Control
const Resizer = preload("res://src/global/resize.gd")

func _on_ready():
	$Camera.current = true
	Resizer._on_start()

func _on_resize():
	Resizer._on_resize()
