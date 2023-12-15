using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a buffer for storing and managing input events.
/// </summary>
public partial class Input_Buffer : Node
{

	

/// <summary>
/// Called when the node is ready to be used. Initialization code should be put here.
/// </summary>
    public override void _Ready()
    {
        buffer_timer = new()
        {
            WaitTime = buffer_time,
            OneShot = true,
        };
		buffer_timer.Timeout += Clear;
        AddChild(buffer_timer);
    }

	/// <summary>
	/// Adds an input event to the input queue.
	/// </summary>
	/// <param name="input">The input event to add.</param>
	public void Add_Input(InputEvent input){
		if(!input.IsActionType()){	return;	}
		if(input_queue.Count != 0){
			if(input_queue.Peek().IsMatch(input)){return;}
		}
		
		input_queue.Enqueue(input);
		buffer_timer.Start();
	}

	/// <summary>
	/// Removes the first input from the input queue.
	/// </summary>
	public void Pop_Input(){
		if(input_queue.Count == 0){return;}
		input_queue.Dequeue();
	}

	/// <summary>
	/// Checks the input queue and returns the next input event without removing it from the queue.
	/// </summary>
	/// <returns>The next input event in the queue, or null if the queue is empty.</returns>
	public InputEvent Check_Queue(){
		if(input_queue.Count == 0){return null;}
		return input_queue.Peek();
	}

	/// <summary>
	/// Clears the input queue.
	/// </summary>
	public void Clear(){

		input_queue.Clear();
	}

	/// <summary>
	/// Timer to clear the buffer when there are no new inputs for too long.
	/// </summary>
	private Timer buffer_timer;
	/// <summary>
	/// The amount of time in seconds that input can be buffered.
	/// </summary>
	[Export]
	private float buffer_time = 0.1f;
	/// <summary>
	/// Represents a queue of input events.
	/// </summary>
	private Queue<InputEvent> input_queue = new();

}
