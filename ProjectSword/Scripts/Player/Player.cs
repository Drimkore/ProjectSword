using Godot;
using System;

public class Player : KinematicBody2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	private int speed = 150;
	private int gravity = 200;
	private AnimationPlayer _animationPlayer;
	private Sprite _spritePlayer;
	public Vector2 motion = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		_spritePlayer = GetNode<Sprite>("Sprite");

	}
	

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
		motion.y += gravity * delta;
		var x_input = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");

		

		if (x_input != 0)
		{
			motion.x += x_input * 500 * delta;
			motion.x = Mathf.Clamp(motion.x, -speed, speed);
			_animationPlayer.Play("Run");

			if (x_input > 0)
			{
				_spritePlayer.FlipH = false;
			}
			else 
				_spritePlayer.FlipH = true;
			
		}
		else 
			motion.x = 0;

		if (motion.x ==0)
			_animationPlayer.Play("RESET");	

		motion = MoveAndSlide(motion, Vector2.Up);
		

  }
}
