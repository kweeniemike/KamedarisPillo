using UnityEngine;
using System.Collections.Generic;

public class Cart : MonoBehaviour
{
	public enum cartColor
	{
		green,
		brown}
	;
	public cartColor color;
	public Score score;
	private FallingObjectCreator objectcounter;
	private List<GameObject> uniqueObjects;

	void OnTriggerEnter (Collider collider)
	{
		GameObject opponent = collider.gameObject;
		if (AddToList(opponent)) {
			opponent.GetComponent<SelfDestruction>().StartTimer();
			if (opponent.tag == "Meloen" && color == cartColor.green) {
				if (opponent.name.StartsWith ("Gouden")) {
					score.addSpecialScore ();
				} else {
					score.addScore ();
				}
				objectcounter.goldMelonCounter++;
				//Destroy(opponent.transform.parent.gameObject);
			} else if (opponent.tag == "Kokosnoot" && color == cartColor.brown) {
				if (opponent.name.StartsWith ("Gouden")) {
					score.addSpecialScore ();
				} else {
					score.addScore ();
				}
				objectcounter.goldKokosnootCounter++;
				//Destroy(opponent.transform.gameObject);
			} else if (opponent.tag == "Kokosnoot" && color == cartColor.green) {
				score.negativeScore ();
				objectcounter.goldMelonCounter = 0;
				//Destroy(opponent.transform.gameObject);
			} else if (opponent.tag == "Meloen" && color == cartColor.brown) {
				score.negativeScore ();
				objectcounter.goldKokosnootCounter = 0;
				//Destroy(opponent.transform.parent.gameObject);
			}
		}
	}

	bool AddToList (GameObject g)
	{
		if (uniqueObjects.Contains (g)) {
			return false;
		} else {
			uniqueObjects.Add (g);
			return true;
		}
	}
}
