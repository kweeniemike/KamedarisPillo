using UnityEngine;
using System.Collections;

public class Blink : MonoBehaviour {
	public Sprite blinkImage;
	public Sprite unblinkImage;
	private SpriteRenderer r;
	public bool blink;
	// Use this for initialization
	void Start () {
		blink=false;
		r = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(blink)
		{
			r.sprite = blinkImage;
			blink = false;
		}
		if(!blink)
		{
			int i = Random.Range(1,25);
			if(i==7)
			{
				blink = true;
			}
			if(blink)
			{
				r.sprite = unblinkImage;
			}
		}
	}
}
