using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	float initX;
	float initY;
	float xThrow;
	float yThrow;

	// shows tooltip with info in inspector
	[Tooltip("In ms^-1")][SerializeField] float xSpeed = 100f;
	[Tooltip("In m")][SerializeField] float xRange = 20f;
	[Tooltip("In ms^-1")][SerializeField] float ySpeed = 100f;
	[Tooltip("In m")][SerializeField] float yRange = 5f;
	[SerializeField] float positionPitchFactor = -5f;	// ratio of change in position to pitch
	[SerializeField] float controlPitchFactor = -2f;
	[SerializeField] float positionYawFactor = -12f;
	[SerializeField] float throwRollFactor = -25f;

	// Use this for initialization
	void Start () {
		// defined to start ship centered on camera
		initX = transform.localPosition.x;
		initY = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		ProcessTranslation();
		ProcessRotation();
	}

	private void ProcessTranslation()
	{
		// refers to controller joystick
		// maps a, d on keyboard to left, right on joystick
		// value in [-1, 1]
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		
		// 80 fps * .066 m = 5.28 m/s
		// compared with xSpeed
		float xOffset = xThrow * xSpeed * Time.deltaTime;

		// use to smoothly translate position instead of instantly translating
		float rawX = transform.localPosition.x + xOffset;
		
		// limit max offset
		float clampedXPos = Mathf.Clamp(rawX, initX - xRange, initX + xRange);

		// translate ship along x-axis
		transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
	
		// translate ship along y-axis
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		float yOffset = yThrow * ySpeed * Time.deltaTime;
		float rawY = transform.localPosition.y + yOffset;
		float clampedYPos = Mathf.Clamp(rawY, initY - yRange, initY + yRange);
		transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
	}

	private void ProcessRotation()
	{
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;	// change pitch when moving along y
		float pitchDueToControlThrow = yThrow * controlPitchFactor;
		float pitch = pitchDueToPosition + pitchDueToControlThrow;
		float yaw = transform.localPosition.x * positionYawFactor;
		float roll = xThrow * throwRollFactor;
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
}
