using Godot;
using System;

enum GameState{
	Wander, //default state 1, nonhostile
	Idle, //default state 2, nonhostile
	Surprised, //interrupts defaults, opens detection logic and transitions to wary or investigating
	Wary, //moves/patrols but is easier to detect player
	Investigating, //moves toward a given position and is easier to detect player
	Reinforcing, //will communicate to rest of enemies to alert them 
	Alerted, //hostile, moves towards player last known position
	Chasing //hostile, actively chasing/attacking player
}
public partial class Enemy : Node3D
{
	public int stat1 = 5;
	public bool stat2 = false;
	public string stat3 = "thing";

}
