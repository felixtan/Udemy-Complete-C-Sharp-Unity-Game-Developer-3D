using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	float initX;
	float initY;
	float xThrow;
	float yThrow;
	bool controlsEnabled = true;

	[Header("General")]
	[Tooltip("In ms^-1")][SerializeField] float xSpeed = 100f;
	[Tooltip("In m")][SerializeField] float xRange = 15f;
	[Tooltip("In ms^-1")][SerializeField] float ySpeed = 100f;
	[Tooltip("In m")][SerializeField] float yRange = 15f;
	[SerializeField] GameObject[] guns;

	[Header("Screen-position Based")]
	[SerializeField] float positionPitchFactor = 1f;	// ratio of change in position to pitch
	[SerializeField] float positionYawFactor = 2f;
	
	[Header("Control-throw Based")]
	[SerializeField] float controlPitchFactor = 1f;
	[SerializeField] float throwRollFactor = 2f;

	// Use this for initialization
	void Start () {
		// defined to start ship centered on camera
		initX = transform.localPosition.x;
		initY = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (controlsEnabled)
		{
			ProcessTranslation();
			ProcessRotation();
			ProcessFiring();
		}
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

	// called by string ref
	void OnPlayerDeath()
	{
		controlsEnabled = false;
	}

	private void ActivateGuns()
	{
		foreach (GameObject gun in guns)
		{
			gun.SetActive(true);
		}
	}

	private void DeactivateGuns()
	{
		foreach (GameObject gun in guns)
		{
			gun.SetActive(false);
		}
	}
	private void ProcessFiring()
	{
		if (CrossPlatformInputManager.GetButton("Fire"))
		{
			ActivateGuns();
		}
		else
		{
			DeactivateGuns();
		}
	}
}
