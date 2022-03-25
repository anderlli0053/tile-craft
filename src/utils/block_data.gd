extends Node
var BLOCK_DATA
func _init():
  var file = File.new()
  file.open("res://data/block_data.json", File.READ)
  BLOCK_DATA = JSON.parse(file.get_as_text()).result
  print(BLOCK_DATA)