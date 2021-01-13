using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	[SerializeField] Waypoint startWp, endWp;
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ColorStartAndEnd();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void ExploreNeighbors(Waypoint wp)
	{
		foreach (Vector2Int direction in directions)
		{
			Vector2Int exploring = wp.GetGridPos() + direction;

			try
			{
				grid[exploring].SetTopColor(Color.blue);
			}
			catch
			{
				// nothing
			}
		}
	}

	private void ColorStartAndEnd()
	{
		startWp.SetTopColor(Color.magenta);
		endWp.SetTopColor(Color.magenta);
	}

	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint wp in waypoints)
		{
			var gridPos = wp.GetGridPos();
			bool isOverlapping = grid.ContainsKey(gridPos);
			if (isOverlapping)
			{
				//
			}
			else
			{
				grid.Add(gridPos, wp);
				// wp.SetTopColor(Color.black);
			}
		}
	}
}
