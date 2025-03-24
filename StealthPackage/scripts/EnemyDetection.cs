using Godot;
using System;

public partial class Enemy : Node3D
{
	public float rayLength = 0;
	public float rayIntegrity = 0;
	private float detectionIncreaseRate = 15f;
	private float detectionDecayRate = 10f;
	private float detectPlayerThreshold = 100f;
	private float currentDetection = 1;
	private bool canSeePlayer = false;
	private GameState currentGameState;

	public void TESTBecomeSurprised()
	{
		GD.Print("gasp I'm so surprised");
		currentGameState = GameState.Surprised;	
	}

	public void TESTChangePlayerVisibility()
	{
		if (Input.IsActionJustPressed("Debug5")){
			
		canSeePlayer = canSeePlayer ? false : true;
		string message = canSeePlayer ? "you visible" : "you ain't visible";
		GD.Print(message);
		}
	}

	//They can see the player and are detecting them
public void TESTCanSeePlayer()
{
	switch (currentGameState)
	{
		case GameState.Wander:
		case GameState.Idle:
			if (canSeePlayer)
			{
				currentDetection = Mathf.Max(0, currentDetection + detectionIncreaseRate * (float)GetProcessDeltaTime());
				GD.Print($"State: {currentGameState} || Current Detection: {(int)currentDetection}");
			}
			else
			{
				currentDetection = Mathf.Max(0, currentDetection - detectionDecayRate * (float)GetProcessDeltaTime());
				GD.Print($"State: {currentGameState} || Current Detection: {(int)currentDetection}");
			}
			if (currentDetection >= detectPlayerThreshold / 2)
			{
				TESTBecomeSurprised();
			}
			break;
		case GameState.Surprised:
			currentGameState = canSeePlayer ? GameState.Wary : GameState.Investigating;
			break;
		case GameState.Wary:
				GD.Print($"State: {currentGameState} || Current Detection: {(int)currentDetection}");
			//if they can see the player while wary, their detecting increases faster
			if (canSeePlayer)
			{
				if (currentDetection >= detectPlayerThreshold)
				{
					currentGameState = GameState.Chasing;
				}
				else
				{
					currentDetection = Mathf.Max(0, currentDetection + detectionIncreaseRate * (float)GetProcessDeltaTime() * 2);
				}
			}
			//otherwise decay the detection, maybe go back to idle? idrk
			else
			{
				currentDetection = Mathf.Max(0, currentDetection - detectionDecayRate * (float)GetProcessDeltaTime());
				//if (currentDetection <= detectPlayerThreshold / 2)
				//{
					//currentGameState = GameState.Idle;
				//}
			}
			break;
			
		case GameState.Investigating:
						//if they can see the player while wary, their detecting increases faster
			if (canSeePlayer)
			{
				if (currentDetection >= detectPlayerThreshold)
				{
					currentGameState = GameState.Chasing;
				}
				else
				{
					currentDetection = Mathf.Max(0, currentDetection + detectionIncreaseRate * (float)GetProcessDeltaTime() * 2);
				}
			}
			//otherwise decay the detection, maybe go back to idle? idrk
			else
			{
				currentDetection = Mathf.Max(0, currentDetection - detectionDecayRate * (float)GetProcessDeltaTime());
				//if (currentDetection <= detectPlayerThreshold / 2)
				//{
					//currentGameState = GameState.Idle;
				//}
			}
			break;
		case GameState.Reinforcing:
		case GameState.Alerted:
				GD.Print($"State: {currentGameState} || Current Detection: {(int)currentDetection}");
			if (canSeePlayer) currentGameState = GameState.Chasing;
			else
			{
				currentDetection = Mathf.Max(0, currentDetection - detectionDecayRate * (float)GetProcessDeltaTime());
				if (currentDetection <= 0)
				{
					currentGameState = GameState.Wary; // Reset after full decay
				}
			}
			break;
		case GameState.Chasing:
			currentDetection = detectPlayerThreshold;
				GD.Print($"State: {currentGameState} || Current Detection: {(int)currentDetection}");
			if (!canSeePlayer) currentGameState = GameState.Alerted;
			break;
		default:
			break;
	}
}

	
	public void _ready()
	{
		currentGameState = GameState.Idle;
		GD.Print(currentGameState.ToString());
	}

	public override void _Process(double delta)
	{
		TESTCanSeePlayer();
		TESTChangePlayerVisibility();

	}

	//public override void _PhysicsProcess(double delta)
	//{
	//var spaceState = GetWorld3D().DirectSpaceState;
	//// use global coordinates, not local to node
	//var query = PhysicsRayQueryParameters2D.Create(Vector2.Zero, new Vector2(50, 100));
	//var result = spaceState.IntersectRay(query);
	//
	////if (result.Count > 0)
	////GD.Print("Hit at point: ", result["position"]);
	//
	//var origin = cam.ProjectRayOrigin
	//
	//}


}
