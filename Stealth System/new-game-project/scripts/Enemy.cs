using Godot;
using System;

enum gameState{
	Wander,
	Idle,
	Surprised,
	Wary,
	Investigating,
	Reinforcing,
	Alerted,
	Chasing
}
public partial class Enemy : Node3D
{
	public int stat1 = 5;
	public bool stat2 = false;
	public string stat3 = "thing";

}
