using Godot;



public partial class Player : Entity
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		State_Manager = GetNode<State_Manager>("state_manager");
		input_Buffer = GetNode<Input_Buffer>("input_buffer");
	}

	
	public override void _PhysicsProcess(double delta)
	{
		State_Manager.Input(input_Buffer.Check_Queue());
		State_Manager.Process(delta);
	}

	public override void _Input(InputEvent @event)
	{
		input_Buffer.Add_Input(@event);
	}

	private State_Manager State_Manager;
	private Input_Buffer input_Buffer;
}


