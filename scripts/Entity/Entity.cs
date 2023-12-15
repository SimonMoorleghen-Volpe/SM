using Godot;


public partial class Entity : CharacterBody2D {

    public Vector2 state_movement = Vector2.Zero;
    public Vector2 external_movement = Vector2.Zero;

    protected virtual void Move(){
        Velocity += state_movement + external_movement;
        MoveAndSlide();
    }

}

