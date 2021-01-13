using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<Waypoint> path;
	// [SerializeField] Waypoint[] path = new Waypoint[6];

	// Use this for initialization
	void Start () {
		StartCoroutine(TraversePath());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// IEnumerator makes it a coroutine
	IEnumerator TraversePath()
	{
		print("Starting patrol");

		for (var i = 0; i < path.Count; i++)
		{
			Waypoint waypoint = path[i];
			Vector3 newPos = waypoint.transform.position;
			newPos.y += gameObject.transform.localScale.y;	// adjust so enemy is "standing" on cube and not inside
			transform.position = newPos;	// move enemy
			print("Visiting block " + waypoint.name);
			SendMessage("ExploreNeighbors", waypoint);
			yield return new WaitForSeconds(1f);	// returns execution to StartCoroutine	 
		}

		print("Ending patrol");
	}
}
