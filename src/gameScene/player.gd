extends KinematicBody2D

var velocity = Vector2.ZERO
var gravity = ProjectSettings.get_setting("physics/2d/default_gravity")

export var player_speed = 64
export var jump_speed = 15000

func _ready():
	set_position(Vector2(0, -60))

func _physics_process(delta):
	if Input.is_action_pressed("left"):
		velocity.x += -player_speed
	if Input.is_action_pressed("right"):
		velocity.x += player_speed
	if Input.is_action_pressed("up"):
		print(is_on_floor())
		if is_on_floor():
			velocity.y = -20000 * delta
			print(velocity.y)
	velocity.x *= 0.7
	velocity.y += gravity * delta
	
	velocity = move_and_slide(velocity, Vector2.UP)
	
