using UnityEngine;
using System.Collections;

public class MovingBackground : MonoBehaviour {
	public float horizontalSpeed = 0.5f;
	public float verticalSpeed = 0f;
	public Renderer r;

	void Awake()
	{
		r = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time * horizontalSpeed,Time.time * verticalSpeed);
		r.material.mainTextureOffset = offset;
	}
}
