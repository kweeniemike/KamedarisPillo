using UnityEngine;
using System.Collections;

public class FallingObjectCreator : MonoBehaviour {
	public GameObject MeloenPrefab;
	public GameObject KokosnootPrefab;
	private int melonCounter=0;
	private int kokosnootCounter=0;
	public int minXPosition;
	public int maxXPosition;
	public int minYPosition ;
	public int maxYPosition;

	// Use this for initialization
	void Start () {
		CreateKokosnoot(new Vector3(0,5,0));
		CreateMelon(new Vector3(3,5,0));
		CreateMelon(new Vector3(-3,6,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M))
		{
			CreateMelon(CreateRandomVector());
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			CreateKokosnoot(CreateRandomVector());
		}
	}
	Vector3 CreateRandomVector()
	{
		float randomX = Random.Range(minXPosition, maxXPosition);
		float randomY = Random.Range(minYPosition, maxYPosition);
		Vector3 vector = new Vector3(randomX, randomY,0);
		return vector;
	}

	void CreateKokosnoot(Vector3 position)
	{
		GameObject t = CreateFallingObject(KokosnootPrefab, position);
		melonCounter++;
		t.name = "Kokosnoot"+melonCounter;
		t.transform.parent = this.transform;
	}

	void CreateMelon(Vector3 position)
	{
		GameObject t = CreateFallingObject(MeloenPrefab, position);
		kokosnootCounter++;
		t.name = "Meloen"+kokosnootCounter;
		t.transform.parent = this.transform;
	}

	GameObject CreateFallingObject(GameObject fallingObject, Vector3 position)
	{
		GameObject g = (GameObject) Instantiate(fallingObject, position, Quaternion.identity);
		return g;
	}
}
