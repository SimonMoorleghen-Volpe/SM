using Godot;



/// <summary>
/// Represents a player entity in the game.
/// </summary>
public partial class Player : Entity
{
	
	/// <summary>
	/// Called when the node is ready to be used. It is called after the node has been added to the scene tree.
	/// </summary>
	public override void _Ready()
	{
		State_Manager = GetNode<State_Manager>("state_manager");
		input_Buffer = GetNode<Input_Buffer>("input_buffer");
		MoveAndSlide();
	}

	
	/// <summary>
	/// Called every physics frame (fixed framerate) during the physics processing step of the scene tree.
	/// </summary>
	/// <param name="delta">The time elapsed since the previous physics frame.</param>
	public override void _PhysicsProcess(double delta)
	{
		State_Manager.Input(input_Buffer.Check_Queue());
		State_Manager.Process(delta);
		Move();
	}

	/// <summary>
	/// Called every frame to handle input events.
	/// </summary>
	/// <param name="@event">The input event to handle.</param>
	public override void _Input(InputEvent @event)
	{
		input_Buffer.Add_Input(@event);
	}

	/// <summary>
	/// The State_Manager instance used by the Player class.
	/// </summary>
	private State_Manager State_Manager;
	/// <summary>
	/// The input buffer for the player.
	/// </summary>
	private Input_Buffer input_Buffer;
}


