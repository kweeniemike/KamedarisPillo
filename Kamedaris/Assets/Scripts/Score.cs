﻿using UnityEngine;
using Sys = System;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
	public BultControl bultcontrol;
	public Player playerInputScript;
	public static bool gameEnded = false;
	public float timeToDeath = 6.0f;
	private float score;
	public float timeBallPoints = 5f;
	private float currentTimeBallPoints = 0f;
	public float timeBallPointsDecay = 0.5f;
	public float normalBallPoints = 100f;
	public float specialBallPoints = 500f;
	private float olTime = 0;
	public List<AudioClip> deathSound;
	public List<AudioClip> ScoreSound;
	public FallingObjectCreator fallingObjectCreator;
	public Texture2D timeLabel;
	public Texture2D scoreLabel;
	public Texture2D scoreScreen;
	public GUIStyle quitBtn = new GUIStyle ();
	public GUIStyle playBtn = new GUIStyle ();
	GUIStyle styleNormal = new GUIStyle ();
	GUIStyle styleMiddle = new GUIStyle ();
	GUIStyle styleOwnScore = new GUIStyle ();
	private bool showScores = false;
	private string text;
	private int minutes;
	private int seconds;
	private int fraction;
	private float highScore = 0;
	public float timeOfEnding = 0f;


	// Use this for initialization
	void Start ()
	{
		score = 0;

		currentTimeBallPoints = timeBallPoints;

		styleNormal.fontSize = 30;
		styleNormal.normal.textColor = Color.yellow;
		styleNormal.hover.textColor = Color.yellow;
		styleNormal.alignment = TextAnchor.MiddleLeft;
		styleNormal.margin = new RectOffset (0, 0, 0, 2);
		styleMiddle.fontSize = 70;
		styleMiddle.normal.textColor = Color.red;
		styleMiddle.hover.textColor = Color.red;
		styleMiddle.alignment = TextAnchor.MiddleRight;

		styleOwnScore.fontSize = 30;
		styleOwnScore.alignment = TextAnchor.MiddleLeft;
		styleOwnScore.margin = new RectOffset (0, 0, 0, 2);
		styleOwnScore.normal.textColor = Color.green;
		styleOwnScore.hover.textColor = Color.green;


		ScoreSaver.Scores newStuff = new ScoreSaver.Scores ("You have not a lot scores yet!", -1);
		ScoreSaver.scorings = ScoreSaver.ListNames (newStuff);//set the properly
		//ScoreSaver.SetList ();
		
	}

	public void negativeScore ()
	{
		var tmp = Camera.main.gameObject.GetComponent<ScreenShake> ();
		tmp.Shake (0.45f);
		//score-=normalBallPoints;
		//AudioSource src = GetComponent<AudioSource>();
		//src.clip = deathSound[Random.Range(0,deathSound.Count)];
		//src.Play();
	}

	public void addScore ()
	{
		score += normalBallPoints;
		string clipName = "Score0" + Random.Range (1, 4).ToString ();
		SoundManager.PlayClipOnce (clipName, 1.00f);
		//AudioSource src = GetComponent<AudioSource>();
		//src.clip = ScoreSound[Random.Range(0,ScoreSound.Count)];
		timeToDeath += currentTimeBallPoints;
		//src.Play();
	}

	void FixedUpdate ()
	{
		if (Score.gameEnded) {
			return;
		}
		if (fallingObjectCreator.startTimerRunning) {
			return;
		}
		timeToDeath -= Time.deltaTime;
		
		minutes = (int)timeToDeath / 60;
		seconds = (int)timeToDeath % 60;
		fraction = (int)(timeToDeath * 100) % 60;
		text = string.Format ("{0:0}:{1:00}:{2:00}", minutes, seconds, fraction);

	
		if (timeToDeath <= 0 && !showScores) {
			highScore = score;
			ScoreSaver.Scores save = new ScoreSaver.Scores (Sys.DateTime.UtcNow.ToString (), score);
			ScoreSaver.scorings = ScoreSaver.ListNames (save);
			showScores = true;
			SoundManager.ToggleMainTheme (false);
			SoundManager.PlayClipOnce ("Victory01", 1f);
			gameEnded = true;
			timeOfEnding = Time.timeSinceLevelLoad;
		}

		if (Time.timeSinceLevelLoad >= 30 && (currentTimeBallPoints > timeBallPoints - timeBallPointsDecay)) {
			currentTimeBallPoints -= timeBallPointsDecay;
		} else if (Time.timeSinceLevelLoad >= 60 && (currentTimeBallPoints > timeBallPoints - (timeBallPointsDecay * 2))) {
			currentTimeBallPoints -= timeBallPointsDecay;
		} else if (Time.timeSinceLevelLoad >= 90 && (currentTimeBallPoints > timeBallPoints - (timeBallPointsDecay * 3))) {
			currentTimeBallPoints -= timeBallPointsDecay;
		} else if (Time.timeSinceLevelLoad >= 120 && (currentTimeBallPoints > timeBallPoints - timeBallPointsDecay * 3.5)) {
			currentTimeBallPoints -= timeBallPointsDecay;
		} else if (Time.timeSinceLevelLoad >= 150 && (currentTimeBallPoints > timeBallPoints - timeBallPointsDecay * 4)) {
			currentTimeBallPoints -= timeBallPointsDecay;
		} else if (Time.timeSinceLevelLoad >= 180 && (currentTimeBallPoints > timeBallPoints - timeBallPointsDecay * 4.5)) {
			currentTimeBallPoints -= timeBallPointsDecay;
		}
	}

	public void addSpecialScore ()
	{
		score += specialBallPoints;
		//AudioSource src = GetComponent<AudioSource>();
		//src.clip = ScoreSound[Random.Range(0,ScoreSound.Count)];
		timeToDeath += currentTimeBallPoints;
		//src.Play();
		string clipName = "GoldenPoint";
		SoundManager.PlayClipOnce (clipName, 1f);

	}

	void OnGUI ()
	{
		if (!showScores) {
			GUI.Label (new Rect (0, -5, 220, 160), scoreLabel);
			GUI.Label (new Rect (Screen.width - 220, -5, 220, 160), timeLabel);

			GUI.Label (new Rect (40, 60, 100, 50), "" + score, styleNormal);
			GUI.Label (new Rect (Screen.width - 105, 60, 100, 50), text, styleNormal);

			if (timeToDeath < 20) {
				//	GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.2f), Sys.Math.Round(timeToDeath,2).ToString(),styleMiddle);
				GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.2f), text, styleMiddle);
			} 
		} else {

			GUI.Label (new Rect (Screen.width / 2 - 275, 40, 600, 550), scoreScreen);
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 50, 200, 600, 550));
			GUILayout.BeginVertical ();
			bool highscoreFound = false;
			foreach (var nam in ScoreSaver.pScorings) {
				//if(nam.Length > 1){
				//GUILayout.Box(nam);
				//Debug.Log(highScore);
				//Debug.Log(nam);
				if (nam != null) {
					if (((string)nam).Equals (highScore.ToString ()) && !highscoreFound) {
						GUILayout.Box (nam, styleOwnScore);
						highscoreFound = true;
					} else {
						GUILayout.Box (nam, styleNormal);
					}
				}
				//}
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();

			if (GUI.Button (new Rect (Screen.width * 0.75f, Screen.height * 0.8f, Screen.width * 0.25f, Screen.height * 0.20f), "", quitBtn)) {
				ScoreSaver.SetData ();
				//Time.timeScale = 1;
				Application.LoadLevel ("WelkomScene");
			}

			if (GUI.Button (new Rect (0, Screen.height * 0.8f, Screen.width * 0.25f, Screen.height * 0.20f), "", playBtn)) {
				ScoreSaver.SetData ();
				//Time.timeScale = 1;
				if(!bultcontrol.fourPlayerMode)
				{
					Application.LoadLevel ("MainScene");
				}
				else
				{
					Application.LoadLevel ("DoubleMainScene");
				}
			}
		}
	}

	void Update ()
	{
		if (showScores) {

			if (Input.GetKey (KeyCode.Backspace)) {
				ScoreSaver.SetData ();
				//Time.timeScale = 1;
				Application.LoadLevel ("WelkomScene");
			}
			if (Input.GetKey (KeyCode.R)) {
				ScoreSaver.SetData ();
				//Time.timeScale = 1;

				if(!bultcontrol.fourPlayerMode)
				{
					Application.LoadLevel ("MainScene");
				}
				else
				{
					Application.LoadLevel ("DoubleMainScene");
				}
			}
			if(Time.timeSinceLevelLoad - timeOfEnding > 5)
			{
				if(playerInputScript.pilloPressure1 >= 0.5f || playerInputScript.pilloPressure2 >= 0.5f)
				{
					ScoreSaver.SetData ();
					//Time.timeScale = 1;
					if(!bultcontrol.fourPlayerMode)
					{
						Application.LoadLevel ("MainScene");
					}
					else
					{
						Application.LoadLevel ("DoubleMainScene");
					}
				}
			}
		}
	}

}
