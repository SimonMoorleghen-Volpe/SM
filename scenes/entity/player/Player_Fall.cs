using Godot;



/// <summary>
/// Represents the falling state of the player entity.
/// </summary>
public partial class Player_Fall : Entity_State
{

/// <summary>
/// Called when the node is ready to be used. It is called after the node has been added to the scene tree and is ready for processing.
/// </summary>
    public override void _Ready()
    {
        base._Ready();
    }

/// <summary>
/// Method called when the player exits the "Player_Fall" state.
/// Resets the Y movement of the entity.
/// </summary>
    public override void Exit()
    {
		entity.state_movement.Y = 0;
    }

/// <summary>
/// Processes the falling behavior of the player.
/// </summary>
/// <param name="delta">The time elapsed since the last frame.</param>
/// <returns>The next state of the player.</returns>
    public override string Process(double delta){
		
		if(entity.IsOnFloor()){
			return "idle";
		}
		entity.state_movement += new Vector2(0, (float)delta * Fall_Acceleration);
		if(entity.state_movement.Y > Fall_Max_Speed){
			entity.state_movement.Y = Fall_Max_Speed;
		}
		return null;
	}

	/// <summary>
	/// The acceleration value for the player's fall.
	/// </summary>
	[Export]
	private float Fall_Acceleration = 1000;
	/// <summary>
	/// The maximum speed at which the player can fall.
	/// </summary>
	[Export]
	private float Fall_Max_Speed = 800;

}


