using Godot;
using System;
using System.IO;

public partial class scene_manager : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(starter_scene == null){
			GetTree().Quit();
		}

		current_scene = (ResourceLoader.Load<PackedScene>(starter_scene)).Instantiate<Node>();
		AddChild(current_scene);
	}

	public void Change_Scene(string NewScenePath){
		if(!File.Exists(NewScenePath)){
			return;
		}

		current_scene.QueueFree();
		current_scene = (ResourceLoader.Load<PackedScene>(NewScenePath)).Instantiate<Node>();
	}



	private Node current_scene;

	[Export(PropertyHint.File)]
	private string starter_scene = null;

}
