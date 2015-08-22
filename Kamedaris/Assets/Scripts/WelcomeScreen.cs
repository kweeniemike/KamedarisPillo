using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
public class WelcomeScreen : MonoBehaviour {
	
	private bool credits = false;
	private bool description = false;
	
	public GUIStyle background;
	public GUIStyle logo;
	public Texture2D t_description;
	public Texture2D t_credits;
	
	public GUIStyle quitBtn = new GUIStyle();
	public GUIStyle playBtn = new GUIStyle();
	
	
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	
	
	
	void OnGUI(){

		GUI.Label (new Rect (0,0, Screen.width, Screen.height), "", background);
		GUI.Label (new Rect (Screen.width * 0.25f,Screen.height * 0.03f, Screen.width * 0.45f, Screen.height * 0.25f),"", logo);
			

		if(GUI.Button(new Rect (Screen.width * 0.08f,Screen.height * 0.25f, Screen.width * 0.17f, Screen.height * 0.17f),"", playBtn )){
			Application.LoadLevel("MainScene");
		}

		if(GUI.Button(new Rect (Screen.width * 0.08f,Screen.height * 0.43f, Screen.width * 0.17f, Screen.height * 0.17f),"Game Guide", "button" )){
			description = !description;
			credits = false;
		}

		if(GUI.Button(new Rect (Screen.width * 0.08f,Screen.height * 0.61f, Screen.width * 0.17f, Screen.height * 0.17f),"credits", "button" )){
			credits = !credits;
			description = false;
		}

		if(GUI.Button(new Rect (Screen.width * 0.08f,Screen.height * 0.79f, Screen.width * 0.17f, Screen.height * 0.17f),"", quitBtn )){
			Application.Quit();
		}

		if(description){
			GUI.Label (new Rect (Screen.width * 0.4f,Screen.height * 0.3f, Screen.width * 0.5f, Screen.height * 0.6f), t_description);
		}

		if(credits){
			GUI.Label (new Rect (Screen.width * 0.4f,Screen.height * 0.3f, Screen.width * 0.5f, Screen.height * 0.6f), t_credits);
		}
	}
}
