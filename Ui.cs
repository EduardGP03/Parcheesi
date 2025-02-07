using Godot;
using System;

public partial class Ui : Control
{
	[Signal]
	public delegate void OnRollDiceEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.AddUserSignal("OnRollDice");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_pressed(){
		EmitSignal("OnRollDice");
	}
}
