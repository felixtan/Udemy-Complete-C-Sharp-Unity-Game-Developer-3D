﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
