using Godot;
using System;
using System.Collections.Generic;


public partial class State_Manager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Entity Par = GetOwner<Entity>();
		foreach(Entity_State child in GetChildren()){
			Add_State(child);
			child.Assign_Entity(Par);
			if(child.Default){
				Current_State = child;
			}
		}



	}

	public bool Input(InputEvent input){
		if(input == null){return false;}
		string input_string = Current_State.In(input);
		if(input_string == null){ return false;}
		Change_State(input_string);
		return true;
	}

	public void Process(double delta){
		Change_State(Current_State.Process(delta));
	}

	public bool Change_State(string newState){
		if(newState == null){return false;}
		if(!State_Dictionary.ContainsKey(newState)){return false;}

		Current_State.Exit();
		Current_State = State_Dictionary[newState];
		Current_State.Enter();
		return true;


	}

	public bool Add_State(Entity_State NewState){
		return State_Dictionary.TryAdd(NewState.State_ID, NewState);
	}

	public bool Remove_State(String State_ID){
		return State_Dictionary.Remove(State_ID);
	}

	private Dictionary<string, Entity_State> State_Dictionary = new();
	private Entity_State Current_State;

}
