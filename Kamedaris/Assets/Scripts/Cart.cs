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
			if(name.StartsWith("Gouden"))
			{
				score.addSpecialScore();
			}
			else
			{
				score.addScore();
			}
			score.addScore();
			objectcounter.goldMelonCounter++;
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.blue)
		{
			if(name.StartsWith("Gouden"))
			{
				score.addSpecialScore();
			}
			else
			{
				score.addScore();
			}
			objectcounter.goldKokosnootCounter++;
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.red)
		{
			score.negativeScore();
			objectcounter.goldMelonCounter=0;
		}
		else if(opponent.tag == "Meloen" && color == cartColor.blue)
		{
			score.negativeScore();
			objectcounter.goldKokosnootCounter=0;
		}
		Destroy(opponent);
	}
}
