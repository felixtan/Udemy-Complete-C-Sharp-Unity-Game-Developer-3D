using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

	[Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
	[Tooltip("Death effect object")][SerializeField] GameObject deathFX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
		deathFX.SetActive(true);	// activate game object
		Invoke("ReloadScene", levelLoadDelay);
	}

	private void StartDeathSequence()
	{
		print("Player dying");
		SendMessage("OnPlayerDeath");
	}

	private void ReloadScene()
	{
		SceneManager.LoadScene(1);
	}
}
