using UnityEngine;
using Sys = System;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {

	private float timeToDeath = 60.0f;
	private float score;
	public float timeBallPoints = 5f;
	public float timeBallPointsDecay = 0.5f;
	public float normalBallPoints = 100f;
	public float specialBallPoints = 500f;
	private float olTime = 0;
	public List<AudioClip> deathSound;
	public List<AudioClip> ScoreSound;

	public Texture2D timeLabel;
	public Texture2D scoreLabel;
	public Texture2D scoreScreen;

	public GUIStyle quitBtn = new GUIStyle();
	public GUIStyle playBtn = new GUIStyle();

	GUIStyle styleNormal = new GUIStyle();
	GUIStyle styleMiddle = new GUIStyle();

	private bool showScores = false;

	private string text;
	private int minutes;
	private int seconds;
	private int fraction;

	// Use this for initialization
	void Start () {
		score = 0;

		styleNormal.fontSize = 30;
		styleNormal.normal.textColor = Color.yellow;
		styleNormal.hover.textColor	 = Color.yellow;
		styleNormal.alignment = TextAnchor.MiddleCenter;

		styleMiddle.fontSize = 70;
		styleMiddle.normal.textColor = Color.red;
		styleMiddle.hover.textColor	 = Color.red;
		styleMiddle.alignment = TextAnchor.MiddleCenter;

		ScoreSaver.Scores newStuff = new ScoreSaver.Scores("You have not a lot scores yet!",-1);
		ScoreSaver.scorings = ScoreSaver.ListNames(newStuff);//set the properly
		//ScoreSaver.SetList ();

		addScore();
		addScore();
		addSpecialScore();
	}

	public void negativeScore(){
		//score-=normalBallPoints;
		//AudioSource src = GetComponent<AudioSource>();
		//src.clip = deathSound[Random.Range(0,deathSound.Count)];
		//src.Play();
	}

	public void addScore(){
		score+=normalBallPoints;
		//AudioSource src = GetComponent<AudioSource>();
		//src.clip = ScoreSound[Random.Range(0,ScoreSound.Count)];
		timeToDeath += timeBallPoints;
		//src.Play();
	}

	void Update(){
		timeToDeath -= Time.deltaTime;
		
		minutes = (int)timeToDeath / 60;
		seconds = (int)timeToDeath % 60;
		fraction = (int)(timeToDeath * 100) % 60;
		text = string.Format("{0:0}:{1:00}:{2:00}", minutes, seconds, fraction);


		if (timeToDeath < 1 && !showScores) {
			ScoreSaver.Scores save = new ScoreSaver.Scores(Sys.DateTime.UtcNow.ToString(),score);
			ScoreSaver.scorings = ScoreSaver.ListNames(save);
			showScores = true;
			Time.timeScale = 0;

		}

		if(Time.timeSinceLevelLoad>=50){
			timeBallPoints-=timeBallPointsDecay;
		}else if(Time.timeSinceLevelLoad>=100){
			timeBallPoints-=timeBallPointsDecay;
		}else if(Time.timeSinceLevelLoad>=150){
			timeBallPoints-=timeBallPointsDecay;
		}

	}

	public void addSpecialScore(){
		score+=specialBallPoints;
		//AudioSource src = GetComponent<AudioSource>();
		//src.clip = ScoreSound[Random.Range(0,ScoreSound.Count)];
		timeToDeath += timeBallPoints;
		//src.Play();
	}

	void OnGUI () {
		if (!showScores) {
			GUI.Label (new Rect (10, 10, 180, 160), scoreLabel);
			GUI.Label (new Rect (Screen.width - 190, 10, 180, 160), timeLabel);

			GUI.Label (new Rect (40, 100, 100, 50), "" + score, styleNormal);
			GUI.Label (new Rect (Screen.width - 165, 100, 100, 50), text, styleNormal);

			if (timeToDeath < 20) {
				//	GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.2f), Sys.Math.Round(timeToDeath,2).ToString(),styleMiddle);
				GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.2f), text, styleMiddle);
			} 
		} else {

			GUI.Label (new Rect (Screen.width/2 - 275, 40, 600, 550), scoreScreen);
			GUILayout.BeginArea(new Rect(Screen.width/2 - 300, 180, 600,550));
			GUILayout.BeginVertical();
	
			foreach (var nam in ScoreSaver.pScorings)
			{
				//if(nam.Length > 1){
					//GUILayout.Box(nam);
				GUILayout.Box(nam,styleNormal);
				//}
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();

			if(GUI.Button(new Rect (Screen.width * 0.47f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.2f),"", quitBtn )){
				ScoreSaver.SetData();
				Time.timeScale =1;
				Application.LoadLevel("Menu");
			}

			if(GUI.Button(new Rect (Screen.width * 0.33f, Screen.height * 0.8f, Screen.width * 0.2f, Screen.height * 0.2f),"", playBtn )){
				ScoreSaver.SetData();
				Time.timeScale =1;
				Application.LoadLevel("testscene");
			}
		}
	}

}
