using Godot;
using System;

public partial class Enemy : Node3D
{
	public float rayLength = 0;
	public float rayIntegrity = 0;
	

	public void TESTDetectSomething()
	{
		if(Input.IsActionJustPressed("Debug1")){
			GD.Print("debug 1");
			
		} 
	}

	public override void _Process(double delta){
		TESTDetectSomething();
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

	public void RayCast()
	{

	}
}
