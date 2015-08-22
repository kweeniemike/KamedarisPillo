using UnityEngine;
using System.Collections;


public class Cart : MonoBehaviour {
	public enum cartColor{red, blue};
	public cartColor color;

	void OnCollisionEnter(Collision collision)
	{
		GameObject opponent = collision.collider.gameObject;
		if(opponent.tag ==  "Meloen" && color == cartColor.red)
		{
			//adscore
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.blue)
		{
			//addscore
		}
		else
		{
			//addNegativeScore
		}
		Destroy(opponent);
	}
}
