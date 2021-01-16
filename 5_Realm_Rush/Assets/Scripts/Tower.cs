using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectToPan;
	[SerializeField] float attackRange = 10f;
	[SerializeField] ParticleSystem projectileParticle;
	EnemyDamage targetEnemy;
	
	// Update is called once per frame
	void Update () {
		SetTargetEnemy();

		if (targetEnemy)
		{
			// https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
			objectToPan.LookAt(targetEnemy.transform);
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

	private void SetTargetEnemy()
	{
		var sceneEnemies = FindObjectsOfType<EnemyDamage>();
		if (sceneEnemies.Length == 0) { 
			return;
		}
		else
		{
			EnemyDamage closestEnemy = sceneEnemies[0];

			foreach (EnemyDamage testEnemy in sceneEnemies)
			{
				closestEnemy = GetClosest(closestEnemy, testEnemy);
			}

			targetEnemy = closestEnemy;
		}
	}

	private EnemyDamage GetClosest(EnemyDamage enemyA, EnemyDamage enemyB)
	{
		float distToA = Vector3.Distance(enemyA.transform.position, gameObject.transform.position);
		float distToB = Vector3.Distance(enemyB.transform.position, gameObject.transform.position);
		if (distToA <= distToB)
		{
			return enemyA;
		}
		else
		{
			return enemyB;
		}
	}
}
