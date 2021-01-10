using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AddNonTriggerBoxCollider();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// programatically add non-trigger box collider 
	void AddNonTriggerBoxCollider()
	{
		Collider nonTriggerBoxCollider = gameObject.AddComponent<BoxCollider>();
		nonTriggerBoxCollider.isTrigger = false;
	}
	void OnParticleCollision(GameObject other)
	{
		Destroy(gameObject);
	}
}
