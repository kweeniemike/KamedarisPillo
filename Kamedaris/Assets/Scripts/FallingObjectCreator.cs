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
	private float startTime;
	private float currentTime;
	public float spawnTime;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () {
		startTime = Time.timeSinceLevelLoad;
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
		currentTime = Time.time - startTime;
		if(currentTime >= lastSpawnTime + spawnTime)
		{
			int r = Random.Range(0,2);
			if(r == 1)
			{
				CreateMelon(CreateRandomVector());
			}
			else{
				CreateKokosnoot(CreateRandomVector());
			}
			lastSpawnTime = currentTime;
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
		GameObject g = CreateFallingObject(KokosnootPrefab, position);
		melonCounter++;
		g.name = "Kokosnoot"+melonCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(0,90,90);
	}

	void CreateMelon(Vector3 position)
	{
		GameObject g = CreateFallingObject(MeloenPrefab, position);
		kokosnootCounter++;
		g.name = "Meloen"+kokosnootCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(0,90,90);	
	}

	GameObject CreateFallingObject(GameObject fallingObject, Vector3 position)
	{
		GameObject g = (GameObject) Instantiate(fallingObject, position, Quaternion.identity);
		return g;
	}
}
