extends Area2D
var collision_num:=0
func _on_body_entered(body):
	collision_num+=1
func _on_body_exited(body):
	collision_num-=1
