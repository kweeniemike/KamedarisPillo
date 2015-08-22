using UnityEngine;
using System.Collections;


public class Cart : MonoBehaviour {
	public enum cartColor{red, blue};
	public cartColor color;
	public Score score;
	public FallingObjectCreator objectcounter;

	void OnCollisionEnter(Collision collision)
	{
		GameObject opponent = collision.collider.gameObject;
		if(opponent.tag ==  "Meloen" && color == cartColor.red)
		{
			if(opponent.name.StartsWith("Gouden"))
			{
				score.addSpecialScore();
			}
			else
			{
				score.addScore();
			}
			objectcounter.goldMelonCounter++;
			Destroy(opponent.transform.parent.gameObject);
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.blue)
		{
			if(opponent.name.StartsWith("Gouden"))
			{
				score.addSpecialScore();
			}
			else
			{
				score.addScore();
			}
			objectcounter.goldKokosnootCounter++;
			Destroy(opponent.transform.gameObject);
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.red)
		{
			score.negativeScore();
			objectcounter.goldMelonCounter=0;
			Destroy(opponent.transform.gameObject);
		}
		else if(opponent.tag == "Meloen" && color == cartColor.blue)
		{
			Debug.Log("Melon Dead");
			score.negativeScore();
			objectcounter.goldKokosnootCounter=0;
			Destroy(opponent.transform.parent.gameObject);
		}
	}
}
