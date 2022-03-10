extends KinematicBody2D

var velocity = Vector2.ZERO
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

export var player_speed = 128
export var jump_speed = 25662

func _ready():
	set_position(Vector2(0, -640))

func _physics_process(delta):
	var input_dir = 0
	if Input.is_action_pressed("left"):
		velocity.x += -player_speed * delta
		input_dir = -1
	if Input.is_action_pressed("right"):
		velocity.x += player_speed * delta
		input_dir = 1
	if Input.is_action_pressed("up"):
		if is_on_floor():
			velocity.y = -jump_speed * delta
	velocity.x *= .7
	velocity.y += gravity * delta
	velocity = move_and_slide(velocity, Vector2.UP, true)
	if is_on_wall():
		move_and_slide(Vector2(player_speed*input_dir*delta, -512))
