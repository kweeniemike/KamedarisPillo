using UnityEngine;
using System.Collections;


public class Cart : MonoBehaviour {
	public enum cartColor{red, blue};
	public cartColor color;
	public Score score;

	void OnCollisionEnter(Collision collision)
	{
		GameObject opponent = collision.collider.gameObject;
		if(opponent.tag ==  "Meloen" && color == cartColor.red)
		{
			score.addScore();
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.blue)
		{
			score.addScore();
		}
		else
		{
			score.negativeScore();
		}
		Destroy(opponent);
	}
}
