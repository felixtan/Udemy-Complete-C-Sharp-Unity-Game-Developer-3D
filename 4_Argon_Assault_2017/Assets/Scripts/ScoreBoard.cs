using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

	int score;
	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();	// object's text component
		scoreText.text = score.ToString();
	}

	// public to allow it to be called externally
	public void ScoreHit(int scoreToAdd)
	{
		score = score + scoreToAdd;
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
