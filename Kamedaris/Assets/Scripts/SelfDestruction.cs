using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {
	public float minimalYPosition;
	public float disappearTime;
	private float endTime;
	private bool start;
	void Awake()
	{
		start = false;
	}

	void OnBecameInvisible() {
		if(transform.position.y<minimalYPosition)
		{;
			if(tag == "Meloen") 
			{
				Destroy(transform.parent.gameObject);
			}
			Destroy(gameObject);
		}
	}
	void FixedUpdate()
	{
		if (Score.gameEnded) {
			return;
		}
		if(start)
		{
			if(Time.timeSinceLevelLoad >= endTime)
			{
				if(tag == "Meloen") 
				{
					Destroy(transform.parent.gameObject);
				}
				Destroy(gameObject);
			}
		}
	}
	public void StartTimer()
	{
		if(!start)
		{
			start = true;
			endTime = Time.timeSinceLevelLoad + disappearTime;
		}
	}
}