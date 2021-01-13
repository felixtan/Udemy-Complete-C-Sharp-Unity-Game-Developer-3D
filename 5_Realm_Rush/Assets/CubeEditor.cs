using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by default, MonoBehaviours are only executed in Play Mode
// this attribute tells callback functions to execute in edit mode as well
[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]	// automatically adds Waypoint component to this object when created
public class CubeEditor : MonoBehaviour {

	Vector3 gridPos;
	Waypoint waypoint;

	private void Awake()
	{
		waypoint = GetComponent<Waypoint>();
	}

	void Update () {
		UpdatePosition();
	}

	void UpdatePosition()
	{
		SnapToGrid();
		UpdateLabel();
	}

	private void SnapToGrid()
	{
		int gridSize = waypoint.GetGridSize();
		Vector2 gridPos = waypoint.GetGridPos(); 
		transform.position = new Vector3(gridPos.x * gridSize, 0f, gridPos.y * gridSize);
	}

	private void UpdateLabel()
	{
		int gridSize = waypoint.GetGridSize();
		Vector2 gridPos = waypoint.GetGridPos(); 
		TextMesh textMesh = GetComponentInChildren<TextMesh>();
		var labelText = (gridPos.x) + "," + (gridPos.y);
		textMesh.text = labelText;
		gameObject.name = labelText;
	}
}
