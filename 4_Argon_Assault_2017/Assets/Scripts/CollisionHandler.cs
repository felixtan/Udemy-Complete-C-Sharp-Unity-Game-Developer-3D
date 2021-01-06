﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		print("Player dying");
		SendMessage("OnPlayerDeath");
	}
}
