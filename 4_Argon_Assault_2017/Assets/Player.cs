using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// refers to controller joystick
		// maps a, d on keyboard to left, right on joystick
		// value in [-1, 1]
		float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		print(horizontalThrow);
	}
}
