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
	Queue<Waypoint> queue = new Queue<Waypoint>();
	bool isRunning = true;
	Waypoint searchCenter;
	List<Waypoint> path = new List<Waypoint>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public List<Waypoint> GetPath()
	{
		if (path.Count == 0)
		{
			LoadBlocks();
			BFS();
			CreatePath();
		}
		return path;
	}

	private void CreatePath()
	{
		SetAsPath(endWp);
		Waypoint prev = endWp.exploredFrom;

		while (prev != startWp) 
		{
			SetAsPath(prev);
			prev = prev.exploredFrom;
		}

		SetAsPath(startWp);
		path.Reverse();
	}

	private void SetAsPath(Waypoint wp)
	{
		path.Add(wp);
		wp.isPlaceable = false;
	}

	private void BFS()
	{
		queue.Enqueue(startWp);

		while (queue.Count > 0 && isRunning)
		{
			searchCenter = queue.Dequeue();

			if (searchCenter == endWp)
			{
				isRunning = false;
				return;
			} else if (searchCenter.isExplored)
			{
				continue;
			}
			else
			{
				searchCenter.isExplored = true;

				// enqueue neighbors
				foreach (Vector2Int direction in directions)
				{
					Vector2Int neighborCoords = searchCenter.GetGridPos() + direction;

					if (grid.ContainsKey(neighborCoords))
					{
						Waypoint neighbor = grid[neighborCoords];

						if (neighbor.isExplored || queue.Contains(neighbor) || searchCenter.exploredFrom == neighbor)
						{
							// nothing
						}
						else
						{
							queue.Enqueue(neighbor);
							neighbor.exploredFrom = searchCenter;
						}
					}
				}
			}			
		}
	}

	// define dictionary of coords to blocks
	private void LoadBlocks()
	{
		var waypoints = FindObjectsOfType<Waypoint>();
		foreach (Waypoint wp in waypoints)
		{
			var gridPos = wp.GetGridPos();

			if (grid.ContainsKey(gridPos))
			{
				//
			}
			else
			{
				grid.Add(gridPos, wp);
			}
		}
	}
}
