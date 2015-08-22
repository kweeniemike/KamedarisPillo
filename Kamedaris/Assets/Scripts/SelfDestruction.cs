using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {
	public float minimalYPosition;
	public float disappearTime;
	public float endTime;
	public float neededEndTime;
	public bool start;
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
		if(start)
		{
			neededEndTime = Time.timeSinceLevelLoad;
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