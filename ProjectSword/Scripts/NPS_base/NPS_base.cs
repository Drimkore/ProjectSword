using Godot;
using System;

public class NPS_base : RigidBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public int Speed = 150;
    private int gravity = 200;
    public Vector2 motion = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        var animSprite = GetNode<AnimatedSprite>("AnimatedSprite");
        animSprite.Playing = true;
    }

    public void OnVisibilityNotifier2DScreenExited()
    {
        QueueFree();
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        motion.y += gravity * delta;
        motion.x += delta * Speed;         
    }
}
