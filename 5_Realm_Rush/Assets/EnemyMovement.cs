using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PathFinder pathFinder = FindObjectOfType<PathFinder>();
		List<Waypoint> path = pathFinder.GetPath();
		print(path.Count);
		// StartCoroutine(TraversePath(path));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// IEnumerator makes it a coroutine
// 	IEnumerator TraversePath(List<Waypoint> path)
// 	{
// 		print("Starting patrol");
// print(path);
// 		// for (var i = 0; i < path.Count; i++)
// 		// {
// 		// 	Waypoint waypoint = path[i];
// 		// 	Vector3 newPos = waypoint.transform.position;
// 		// 	newPos.y += gameObject.transform.localScale.y;	// adjust so enemy is "standing" on cube and not inside
// 		// 	transform.position = newPos;	// move enemy
// 		// 	yield return new WaitForSeconds(1f);	// returns execution to StartCoroutine	 
// 		// }

// 		print("Ending patrol");
// 	}
}
