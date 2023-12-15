using Godot;
using System;


/// <summary>
/// Represents the idle state of the player entity.
/// </summary>
public partial class Player_Idle : Entity_State
{
    /// <summary>
    /// Processes the idle state based on the given delta time.
    /// </summary>
    /// <param name="delta">The time elapsed since the last frame.</param>
    /// <returns>The next state to transition to, or null if no transition is needed.</returns>
    public override String Process(double delta)
    {
        if(Input.IsActionPressed("move_left") || Input.IsActionPressed("move_right")){
            return "move";
        }
        if(!entity.IsOnFloor()){
            return "fall";
        }
        return null;
    }

    /// <summary>
    /// Handles the input events during the idle state.
    /// </summary>
    /// <param name="input">The input event to handle.</param>
    /// <returns>The next state to transition to, or null if no transition is needed.</returns>
    public override string In(InputEvent input)
    {
        if(input.IsActionPressed("move_up")){
            return "jump";
        }
        return null;
    }
}

