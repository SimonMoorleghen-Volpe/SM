using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Input_Buffer : Node
{

	

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

	public void Add_Input(InputEvent input){
		if(input_queue.Peek().IsMatch(input)){return;}
		input_queue.Enqueue(input);
		buffer_timer.Start();
	}

	public void Pop_Input(){
		if(input_queue.Count() == 0){return;}
		input_queue.Dequeue();
	}

	public InputEvent Check_Queue(){
		if(input_queue.Count() == 0){return null;}
		return input_queue.Peek();
	}

	public void Clear(){
		input_queue.Clear();
	}

	private Timer buffer_timer;
	[Export]
	private float buffer_time = 0.1f;
	private Queue<InputEvent> input_queue = new();

}
