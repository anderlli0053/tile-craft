extends KinematicBody2D

const CONSTANTS = preload("res://src/misc/constants.gd")

var velocity = Vector2.ZERO

func _ready():
	set_position(Vector2(0, -60))

func _physics_process(delta):
	if Input.is_action_pressed("left"):
		velocity.x += -CONSTANTS.PLAYER_SPEED
	elif Input.is_action_pressed("right"):
		velocity.x += CONSTANTS.PLAYER_SPEED
	if Input.is_action_pressed("up"):
		print(is_on_floor())
		if is_on_floor():
			velocity.y -= 30
	velocity.x *= 0.7
	velocity.y += CONSTANTS.GRAVITY * delta
	velocity = move_and_slide(velocity, Vector2(0, -1))
