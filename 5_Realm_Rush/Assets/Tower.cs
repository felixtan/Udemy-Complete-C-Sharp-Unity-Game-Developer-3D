using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
		objectToPan.LookAt(targetEnemy);
	}
}
