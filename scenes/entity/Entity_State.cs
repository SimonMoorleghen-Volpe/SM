using Godot;


public partial class Entity_State : Node
{
	[Export]
	public string State_ID {get; private set;} = "none";
	[Export]
	public bool Default = false;
	private Entity Entity;

	public virtual string In(InputEvent input){
		return null;
	}

	public void Assign_Entity(Entity owner){
		Entity = owner;
	}

	public virtual string Process(double delta){
		return null;
	}

	public virtual void Enter(){}

	public virtual void Exit(){}
}



