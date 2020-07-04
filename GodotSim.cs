using Godot;
using System;
using FRCSim;

public class GodotSim : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Label>("Label").Text = "Network Status: Unknown";
		EventManager.Pinged += Pinged;		
	}

	private void Pinged()
	{
		GetNode<Label>("Label").Text = "Network Status: Pinged";
		GD.Print("Pinged");
	}


	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
