using UnityEngine;
using System.Collections;

public class BultControl : MonoBehaviour {

	public GameObject bult01;
	public float newExValue = 0.5f;
	private float currentExValue = 0.5f;
	public float newRotValue = 0f;
	private float currentRotValue = 0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (newExValue != currentExValue) {
			currentExValue = newExValue;
			Expand(currentExValue, bult01);
		}
		if (newRotValue != currentRotValue) {
			currentRotValue = newRotValue;
			Rotate(currentRotValue, bult01);
		}
	}

	void Rotate(float rotation, GameObject bult)
	{
		bult.transform.Rotate(new Vector3(bult.transform.rotation.eulerAngles.x, bult.transform.rotation.eulerAngles.y, rotation));
	}

	void Expand(float size, GameObject bult)
	{
		bult.transform.localScale = new Vector3(bult.transform.localScale.x, size, bult.transform.localScale.z);
		//Debug.Log (bult.transform.localScale);
	}
}
