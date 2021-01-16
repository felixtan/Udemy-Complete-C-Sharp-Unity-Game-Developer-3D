﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] float attackRange = 10f;
	[SerializeField] ParticleSystem projectileParticle;
	
	// Update is called once per frame
	void Update () {
		if (targetEnemy)
		{
			// https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
			objectToPan.LookAt(targetEnemy);
			FireAtEnemy();
		}
		else
		{
			Shoot(false);
		}
	}

	private void FireAtEnemy()
	{
		float distToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		print("distToEnemy: " + distToEnemy);
		if (distToEnemy <= attackRange)
		{
			Shoot(true);
		}
		else
		{
			Shoot(false);
		}
	}
	
	// toggle bullet particle emmission
	private void Shoot(bool isActive)
	{
		if (projectileParticle != null) {
			var emissionModule = projectileParticle.emission;
			emissionModule.enabled = isActive;
		}
	}
}
