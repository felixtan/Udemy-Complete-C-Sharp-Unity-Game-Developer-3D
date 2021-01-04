using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

	float initX;

	// shows tooltip with info in inspector
	[Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
	[Tooltip("In m")][SerializeField] float xRange = 5f;

	// Use this for initialization
	void Start () {
		// defined to start ship centered on camera
		initX = transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
		// refers to controller joystick
		// maps a, d on keyboard to left, right on joystick
		// value in [-1, 1]
		float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		
		// 80 fps * .066 m = 5.28 m/s
		// compared with xSpeed
		float xOffset = xThrow * xSpeed * Time.deltaTime;

		// use to smoothly translate position instead of instantly translating
		float raw = transform.localPosition.x + xOffset;
		
		// limit max offset
		float clampedXPos = Mathf.Clamp(raw, initX - xRange, initX + xRange);

		// translate ship along x-axis
		transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
	}
}
