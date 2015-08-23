using UnityEngine;
using System.Collections;

public class WheelRotator : MonoBehaviour {

	public float speed = 50f;
	// Use this for initialization
	void Start () {
		StartCoroutine (SqueeckyWheels());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0,0 , speed* Time.deltaTime));
	}

	IEnumerator SqueeckyWheels()
	{
		int seconds = Random.Range (8, 15 + 1);
		while (!Score.gameEnded) {
			string clipName = "Squeek0" + Random.Range (1, 3).ToString ();
			SoundManager.PlayClipOnce (clipName, 0.5f);

			yield return new WaitForSeconds(seconds);
			seconds = Random.Range(8, 15 + 1);
		}
	}
}
