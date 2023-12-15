using Godot;
using System;


public partial class Player_Idle : Entity_State
{


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

    public override string In(InputEvent input)
    {
        if(input.IsActionPressed("move_up")){
            return "jump";
        }
        return null;
    }
}

