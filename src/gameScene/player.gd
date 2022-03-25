extends KinematicBody2D

var velocity = Vector2.ZERO
var just_touched_floor = false
const CONSTANTS = preload("res://src/utils/constants.gd")
var last_input_dir = 1


func _ready():
	set_position(Vector2(0, -640))

func _physics_process(delta):
	var prev_velocity = velocity
	var input_dir = 0
	if Input.is_action_pressed("left"):
		velocity.x += -CONSTANTS.PLAYER_SPEED * delta
		input_dir = -1
		last_input_dir = -1
	if Input.is_action_pressed("right"):
		velocity.x += CONSTANTS.PLAYER_SPEED * delta
		input_dir = 1
		last_input_dir = 1
	if Input.is_action_pressed("up"):
		if is_on_floor():
			velocity.y = -CONSTANTS.JUMP_SPEED * delta
	velocity.x *= .7
	velocity.y += CONSTANTS.GRAVITY * delta
	velocity = move_and_slide(velocity, Vector2.UP, true)
	$StepChecker.scale.x = last_input_dir
	if is_on_floor():
		if is_on_wall() && input_dir:
			if $StepChecker.collision_num == 0:
				move_local_y(-32)
				move_local_x(input_dir)
		elif just_touched_floor:
			var fall_damage = pow(prev_velocity.y/CONSTANTS.TILE_SIZE,2)/2*CONSTANTS.GRAVITY
			print(fall_damage)
		just_touched_floor = false
	else:
		just_touched_floor = true
					
