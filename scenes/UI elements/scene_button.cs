using Godot;
using System;

/// <summary>
/// Represents a button in the scene that can change the current scene when pressed.
/// </summary>
public partial class scene_button : Button
{

	/// <summary>
	/// Called when the node is ready to be used. It is called after the node has been added to the scene tree and is ready for processing.
	/// </summary>
    public override void _Ready()
    {
        Pressed += Change_Scene;
    }

	/// <summary>
	/// Changes the scene to the specified target scene.
	/// </summary>
	private void Change_Scene(){
		GetTree().Root.GetNode<scene_manager>("scene_manager").Change_Scene(target_scene);

	}

	/// <summary>
	/// The target scene that this button will navigate to.
	/// </summary>
    [Export]
	private string target_scene = null;


}
