using Godot;



public partial class Player_Fall : Entity_State
{
	public override string Process(double delta){
		

		return null;
	}

	[Export]
	private float Fall_Acceleration = 1000;
	[Export]
	private float Fall_Max_Speed = 800;

}


