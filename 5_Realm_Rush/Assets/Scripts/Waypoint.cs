using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	[Tooltip("Size of snap increments")]
	const int gridSize = 10;	// dont let it be an instance var; make it uniform for all instances
	Vector2Int gridPos;
	public bool isExplored = false;
	public Waypoint exploredFrom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / gridSize),
			Mathf.RoundToInt(transform.position.z / gridSize)
		);
	}

	public void SetTopColor(Color color)
	{
		MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		topMeshRenderer.material.color = color;
	}
}
