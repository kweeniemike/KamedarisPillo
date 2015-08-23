using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	private static Dictionary<string, AudioSource> sounds = new Dictionary<string, AudioSource>();


	// Use this for initialization
	void Start () {
		AudioSource[] tempSounds = this.GetComponents<AudioSource> ();
		foreach (AudioSource sound in tempSounds) {
			sounds.Add(sound.clip.name, sound);
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown(KeyCode.P))
		{
			toggleMainTheme(false);
			PlaySongOnce("Victory01");
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			PlaySongOnce("WatermelonSplat01");
		}
		//*/
	}

	//Method for playing songs by name for once
	//Method for playing the theme music and not?
	//List of sounds and when they are played:
	/*
	 * music - Main theme
	 * Score 01 - punt scored
	 * Score 02 - punt scored
	 * Score 03 - punt scored
	 * Squeek 01 - "Random" om de zoveel tijd voor de wielen die bewegen
	 * Squeek 02 - Zie hierboven
	 * Victory03 - Level Behaald
	 * Watermeloen Splat01 - 02 - 03 - Sound effects bij error?
	 */

	public static void PlaySongOnce(string name)
	{
		AudioSource sound = sounds [name];
		sound.PlayOneShot(sound.clip);
	}

	public static void toggleMainTheme(bool active)
	{
		AudioSource mainMusic = sounds ["MainMusic"];
		if (active && !mainMusic.isPlaying) {
			mainMusic.Play ();
		} else if (!active && mainMusic.isPlaying) {
			mainMusic.Stop ();
		}
	}




}
