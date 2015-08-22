using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {
	public float minimalYPosition;

	void OnBecameInvisible() {
		if(transform.position.y<minimalYPosition)
		{
			Debug.Log("Dead");
			if(tag == "Meloen") 
			{
				Debug.Log("Melon Dead");
				Destroy(transform.parent.gameObject);
			}
			Destroy(gameObject);
		}
	}
}