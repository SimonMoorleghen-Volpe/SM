using Godot;



public partial class Player_Fall : Entity_State
{

    public override void _Ready()
    {
        base._Ready();
    }

    public override void Enter()
    {
		
    }

    public override void Exit()
    {
		entity.state_movement.Y = 0;
    }

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

	[Export]
	private float Fall_Acceleration = 1000;
	[Export]
	private float Fall_Max_Speed = 800;

}


