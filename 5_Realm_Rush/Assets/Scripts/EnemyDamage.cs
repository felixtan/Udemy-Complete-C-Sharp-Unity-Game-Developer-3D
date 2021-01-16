using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	[SerializeField] int hitPoints = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	private void OnParticleCollision(GameObject other)
	{
		ProcessHit();
	}

	void ProcessHit()
	{
		hitPoints -= 1;

		if (hitPoints < 1) {
			Destroy(gameObject);
		}
	}
}
