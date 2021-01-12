using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	const int gridSize = 10;	// dont let it be an instance var; make it uniform for all instances

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

	public Vector2 GetGridPos()
	{
		return new Vector2(
			Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
			Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
		);
	}
}
