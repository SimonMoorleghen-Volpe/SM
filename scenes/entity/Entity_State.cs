using Godot;


public partial class Entity_State : Node
{
	/// <summary>
	/// The string ID for the state.
	/// </summary>
	[Export]
	public string State_ID {get; private set;} = "none";
	/// <summary>
	/// Specifies whether this state is the default state.
	/// </summary>
	[Export]
	public bool Default = false;
	/// <summary>
	/// The protected field that holds a reference to the entity.
	/// </summary>
	protected Entity entity;

	/// <summary>
	/// Handles the input event and returns a string.
	/// </summary>
	/// <param name="input">The input event to handle.</param>
	/// <returns>A string representing the result of handling the input event.</returns>
	public virtual string In(InputEvent input){
		return null;
	}

	/// <summary>
	/// Assigns an entity to the state.
	/// </summary>
	/// <param name="owner">The entity to assign.</param>
	public void Assign_Entity(Entity owner){
		entity = owner;
	}

	/// <summary>
	/// Processes the entity state.
	/// </summary>
	/// <param name="delta">The time elapsed since the last frame.</param>
	/// <returns>The result of the processing.</returns>
	public virtual string Process(double delta){
		return null;
	}

	/// <summary>
	/// This method is called when the entity enters this state.
	/// </summary>
	public virtual void Enter(){}

	/// <summary>
	/// This method is called when the entity state is exited.
	/// </summary>
	public virtual void Exit(){}
}



