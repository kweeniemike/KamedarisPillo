using UnityEngine;
using System.Collections;

public class RotateTowards : MonoBehaviour {
	public GameObject objectTo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.LookAt (objectTo.transform.position);
	}
}
