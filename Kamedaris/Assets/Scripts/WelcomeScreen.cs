using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class WelcomeScreen : MonoBehaviour {
	
	private bool credits = false;
	private bool description = false;

	public Player playerInputScript;

	public GUIStyle background;
	public GUIStyle logo;
	public Texture2D t_description;
	public Texture2D t_credits;
	
	public GUIStyle quitBtn = new GUIStyle();
	public GUIStyle playBtn = new GUIStyle();
	public GUIStyle creditBtn = new GUIStyle();
	public GUIStyle descrBtn = new GUIStyle();
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
		if (Input.GetKey (KeyCode.R) || playerInputScript.pilloPressure1 >= 0.5f || playerInputScript.pilloPressure2 >= 0.5f) {
			Application.LoadLevel("MainScene");
		}
		if (Input.GetKey (KeyCode.D)) {
			description = !description;
			credits = false;
		}
		if (Input.GetKey (KeyCode.C)) {
			credits = !credits;
			description = false;
		}


	}
	
	void OnGUI(){

		GUI.Label (new Rect (0,0, Screen.width, Screen.height), "", background);
		//GUI.Label (new Rect (Screen.width * 0.25f,Screen.height * 0.03f, Screen.width * 0.45f, Screen.height * 0.25f),"", logo);
			

		if(GUI.Button(new Rect (Screen.width * 0.38f,Screen.height * 0.25f, Screen.width * 0.17f, Screen.height * 0.17f),"", playBtn )){
			Application.LoadLevel("MainScene");
		}

		if(GUI.Button(new Rect (Screen.width * 0.38f,Screen.height * 0.43f, Screen.width * 0.17f, Screen.height * 0.17f),"", descrBtn )){
			description = !description;
			credits = false;
		}

		if(GUI.Button(new Rect (Screen.width * 0.38f,Screen.height * 0.61f, Screen.width * 0.17f, Screen.height * 0.17f),"", creditBtn )){
			credits = !credits;
			description = false;
		}

		if(GUI.Button(new Rect (Screen.width * 0.38f,Screen.height * 0.79f, Screen.width * 0.17f, Screen.height * 0.17f),"", quitBtn )){
			Application.Quit();
		}

		if(description){
			GUI.Label (new Rect (Screen.width * 0.55f,Screen.height * 0.3f, Screen.width * 0.5f, Screen.height * 0.6f), t_description);
		}

		if(credits){
			GUI.Label (new Rect (Screen.width * 0.55f,Screen.height * 0.3f, Screen.width * 0.5f, Screen.height * 0.6f), t_credits);
		}
	}
}
