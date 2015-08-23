using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {
	private static Dictionary<string, AudioSource> sounds = new Dictionary<string, AudioSource>();
	private static Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();
	public List<AudioClip> clipsUsed;
	// Use this for initialization
	void Awake () {
		sounds = new Dictionary<string, AudioSource>();
		clips = new Dictionary<string, AudioClip>();
		AudioSource[] tempSounds = this.GetComponents<AudioSource> ();
		foreach (AudioSource sound in tempSounds) {
			sounds.Add(sound.clip.name, sound);
		}
		foreach (AudioClip clip in clipsUsed) {
			clips.Add(clip.name, clip);
		}
	}
	
	// Update is called once per frame
	void Update () {
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

	public static void PlayClipOnce(string name, float volume)
	{
		AudioClip clip = clips [name];
		AudioSource.PlayClipAtPoint (clip, Vector3.zero, volume);
	}

	public static void ToggleMainTheme(bool active)
	{
		AudioSource mainMusic = sounds ["MainMusic"];
		if (active && !mainMusic.isPlaying) {
			mainMusic.Play ();
		} else if (!active && mainMusic.isPlaying) {
			mainMusic.Stop ();
		}
	}




}
