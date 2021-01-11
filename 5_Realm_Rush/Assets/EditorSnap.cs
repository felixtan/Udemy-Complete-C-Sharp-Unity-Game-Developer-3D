using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// by default, MonoBehaviours are only executed in Play Mode
// this attribute tells callback functions to execute in edit mode as well
[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {

	[Tooltip("Size of snap increments")]
	[SerializeField] [Range(1f, 20f)]float gridSize = 10f;

	void Update () {
		Vector3 snapPos;
		snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		// snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
		snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
	}
}
