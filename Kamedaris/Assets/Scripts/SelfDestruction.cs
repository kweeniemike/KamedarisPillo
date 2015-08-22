﻿using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {
	public float minimalYPosition;

	void OnBecameInvisible() {
		if(transform.position.y<minimalYPosition)
		{
			Destroy(gameObject);
		}
	}
}