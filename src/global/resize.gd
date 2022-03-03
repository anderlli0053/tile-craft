extends Node

static func _on_start():
	var width:int = 1280
	var height:int = 720
	var file: = File.new()
	if file.file_exists("user://window_size.txt"):
		print(file.file_exists("user://window_size.txt"))
		file.open("user://window_size.txt", File.READ)
		var content = file.get_as_text().split("\n")
		width = content[0]
		height = content[1]
		file.close()
	OS.set_window_size(Vector2())

static func _on_resize():
	
	var file: = File.new()
	print(file.open("user://window.json", File.WRITE))
	var content = [OS.get_window_safe_area().size.x, OS.get_window_safe_area().size.y]
	content.join("\n")
	file.write(content)
	file.close()
	OS.set_window_size(Vector2())