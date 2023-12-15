using Godot;
using System;
using System.IO;

public partial class scene_manager : Node
{
	
	/// <summary>
	/// Called when the node is ready to be used. This is where initialization code should be placed.
	/// </summary>
	public override void _Ready()
	{
		if(starter_scene == null){
			GetTree().Quit();
		}

		current_scene = (ResourceLoader.Load<PackedScene>(starter_scene)).Instantiate<Node>();
		AddChild(current_scene);
	}

	/// <summary>
	/// Changes the current scene to the specified scene path.
	/// </summary>
	/// <param name="NewScenePath">The path of the new scene to load.</param>
	public void Change_Scene(string NewScenePath){
		if(!File.Exists(NewScenePath)){
			return;
		}

		current_scene.QueueFree();
		current_scene = (ResourceLoader.Load<PackedScene>(NewScenePath)).Instantiate<Node>();
	}



	/// <summary>
	/// The current scene node.
	/// </summary>
	private Node current_scene;

	/// <summary>
	/// The path to the starter scene.
	/// </summary>
	[Export(PropertyHint.File)]
	private string starter_scene = null;

}
