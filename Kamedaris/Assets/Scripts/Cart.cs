using UnityEngine;
using System.Collections;


public class Cart : MonoBehaviour {
	public enum cartColor{green, brown};
	public cartColor color;
	public Score score;
	public FallingObjectCreator objectcounter;

	void OnTriggerEnter(Collider collider)
	{
		GameObject opponent = collider.gameObject;
		if(opponent.tag ==  "Meloen" && color == cartColor.green)
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
			//Destroy(opponent.transform.parent.gameObject);
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.brown)
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
			//Destroy(opponent.transform.gameObject);
		}
		else if(opponent.tag == "Kokosnoot" && color == cartColor.green)
		{
			score.negativeScore();
			objectcounter.goldMelonCounter=0;
			//Destroy(opponent.transform.gameObject);
		}
		else if(opponent.tag == "Meloen" && color == cartColor.brown)
		{
			score.negativeScore();
			objectcounter.goldKokosnootCounter=0;
			//Destroy(opponent.transform.parent.gameObject);
		}
	}
}
