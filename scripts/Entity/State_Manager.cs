using Godot;
using System;
using System.Collections.Generic;


/// <summary>
/// Manages the states of an entity.
/// </summary>
public partial class State_Manager : Node
{
	
	/// <summary>
	/// Called when the node is ready to be used. Initializes the state manager by adding states, assigning the entity, and setting the default state.
	/// </summary>
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

	/// <summary>
	/// Handles the input event and changes the state accordingly.
	/// </summary>
	/// <param name="input">The input event to be processed.</param>
	/// <returns>True if the input event was successfully processed and the state was changed, otherwise false.</returns>
	public bool Input(InputEvent input){
		if(input == null){return false;}
		string input_string = Current_State.In(input);
		if(input_string == null){ return false;}
		Change_State(input_string);
		return true;
	}

	/// <summary>
	/// Processes the current state of the entity.
	/// </summary>
	/// <param name="delta">The time elapsed since the last frame.</param>
	public void Process(double delta){
		Change_State(Current_State.Process(delta));
	}

	/// <summary>
	/// Changes the state of the entity.
	/// </summary>
	/// <param name="newState">The new state to change to.</param>
	/// <returns>True if the state was changed successfully, false otherwise.</returns>
	public bool Change_State(string newState){
		if(newState == null){return false;}
		if(!State_Dictionary.ContainsKey(newState)){return false;}

		Current_State.Exit();
		Current_State = State_Dictionary[newState];
		Current_State.Enter();
		return true;
	}

	/// <summary>
	/// Adds a new state to the state dictionary.
	/// </summary>
	/// <param name="NewState">The new state to add.</param>
	/// <returns>True if the state was successfully added, false otherwise.</returns>
	public bool Add_State(Entity_State NewState){
		return State_Dictionary.TryAdd(NewState.State_ID, NewState);
	}

	/// <summary>
	/// Removes a state from the state dictionary.
	/// </summary>
	/// <param name="State_ID">The ID of the state to be removed.</param>
	/// <returns>True if the state was successfully removed, false otherwise.</returns>
	public bool Remove_State(String State_ID){
		return State_Dictionary.Remove(State_ID);
	}

	/// <summary>
	/// A dictionary that maps state names to entity states.
	/// </summary>
	private Dictionary<string, Entity_State> State_Dictionary = new();
	/// <summary>
	/// The current state of the entity.
	/// </summary>
	private Entity_State Current_State;

}
