using UnityEngine;
using System.Collections;

public class BultControl : MonoBehaviour {

	public GameObject bult01;
	public GameObject bult02;

	public float newRotValue = 0f;
	public Player playerInputScript;
	public float exMin = 0.4f;
	public float exMax = 2f;

	private float currentRotValue = 0f;
	private bool rotating = false;

	public float newExValue = 0.5f;
	public float newExValue2 = 0.5f;
	private float currentExValue = 0.5f;
	private bool expanding = false;
	private float currentExValue2 = 0.5f;
	private bool expanding2 = false;

	private Vector3 v3ToRot = Vector3.zero;
	private Vector3 v3CurrentRot;
	private float speedRot = 5f;

	private Vector3 v3ToEx = Vector3.zero;
	private Vector3 v3CurrentEx;
	private float speedEx = 5f;

	// Use this for initialization
	void Start () {
		v3CurrentRot = bult01.transform.eulerAngles;
		v3CurrentEx = bult01.transform.localScale;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (playerInputScript.pilloPressure1 > 0.1) {
			newExValue = Mathf.Clamp (playerInputScript.pilloPressure1 * (exMax - exMin), exMin, exMax);
		} else {
			newExValue = exMin;
		}
		if (playerInputScript.pilloPressure2 > 0.1) {
			newExValue2 = Mathf.Clamp (playerInputScript.pilloPressure2 * (exMax - exMin), exMin, exMax);
		}
		else {
			newExValue2 = exMin;
		}
		//newExValue = Mathf.Clamp (playerInputScript.pilloPressure1, exMin, exMax);
		//newExValue2 = Mathf.Clamp (playerInputScript.pilloPressure2, exMin, exMax);
		//Debug.Log (newExValue + ";" + expanding);
		if (Mathf.Abs(newExValue - currentExValue) > 0.01f) {
			currentExValue = newExValue;
			StartCoroutine(Expand(currentExValue, bult01, 1));
		}
		if (Mathf.Abs(newExValue2 - currentExValue2) > 0.01f) {
			currentExValue2 = newExValue2;
			StartCoroutine(Expand(currentExValue2, bult02, 2));
		}
		//Debug.Log ("1" + expanding + "-2" + expanding2);
		/*if (newRotValue != currentRotValue && !rotating) {
			currentRotValue = newRotValue;
			StartCoroutine(Rotate(currentRotValue, bult01));
			rotating = true;
		}*/
		//Debug.Log (rotating);
	}

	IEnumerator Rotate(float rotation, GameObject bult)
	{
		//Debug.Log(Vector3.Distance(v3ToRot, v3CurrentRot));
		v3ToRot = new Vector3 (bult.transform.rotation.eulerAngles.x, bult.transform.rotation.eulerAngles.y, rotation);
		while(Vector3.Distance(v3ToRot, v3CurrentRot) > 0.05f)
		{
			v3CurrentRot = Vector3.Lerp(v3CurrentRot, v3ToRot, Time.deltaTime * speedRot);
			bult.transform.eulerAngles = v3CurrentRot; 
			yield return null;
		}
		rotating = false;
	}

	IEnumerator Expand(float size, GameObject bult, int number)
	{
		//Debug.Log(Vector3.Distance(v3ToEx, v3CurrentEx));
		v3ToEx = new Vector3 (bult.transform.localScale.x, size, bult.transform.localScale.z);
		while (Vector3.Distance(v3ToEx, v3CurrentEx) > 0.05f) {
			v3CurrentEx = Vector3.Lerp (v3CurrentEx, v3ToEx, Time.deltaTime * speedEx);
			bult.transform.localScale = v3CurrentEx; 
			yield return new WaitForFixedUpdate();
		}
		expanding = false;
		//expanding2 = false;
	}
}
