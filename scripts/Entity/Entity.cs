using Godot;


public partial class Entity : CharacterBody2D {

    /// <summary>
    /// Part of the movement vector of the Entity. 
    /// Affected by the Entity itself through it's states.
    /// </summary>
    public Vector2 state_movement = Vector2.Zero;
    /// <summary>
    /// Part of the movement Vector of the Entity.
    /// Effected by outside forces on the Entity.
    /// </summary>
    public Vector2 external_movement = Vector2.Zero;

    /// <summary>
    /// Moves the entity by adding the state_movement and external_movement vectors to the velocity and then calls MoveAndSlide().
    /// </summary>
    protected virtual void Move(){
        Velocity = state_movement + external_movement;
        MoveAndSlide();
    }

}

