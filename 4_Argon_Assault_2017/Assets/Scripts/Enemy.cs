using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;

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
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);	// create deathFX object at enemy's position with no rotation
		fx.transform.parent = parent;	// move death effect to parent and prevent them spawning at the root of the hierarchy
		Destroy(gameObject);
	}
}
