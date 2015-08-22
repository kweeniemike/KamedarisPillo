using UnityEngine;
using System.Collections;

public class FallingObjectCreator : MonoBehaviour {
	public GameObject MeloenPrefab;
	public GameObject GoudenMeloenPrefab;
	public GameObject GoudenKokosnootPrefab;
	public GameObject KokosnootPrefab;
	private int melonCounter=0;
	private int kokosnootCounter=0;
	public float minXPosition;
	public float maxXPosition;
	public float minYPosition ;
	public float maxYPosition;
	private float startTime;
	private float currentTime;
	public float spawnTime;
	private float lastSpawnTime;
	public int goldMelonCounter;
	public int goldKokosnootCounter;
	public float timeReduction;
	public float timeInterval;
	public float lowestSpawnTime;
	public float highestSpawnTime;
	private float nextReduction;

	// Use this for initialization
	void Start () {
		nextReduction = timeInterval;
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		KeyInput();
		SpawnOnTimer();
		GoldObjectSpawner();
	}
	void KeyInput()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			CreateMelon(CreateRandomVector());
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			CreateKokosnoot(CreateRandomVector());
		}
	}

	void SpawnOnTimer()
	{
		if(currentTime >= nextReduction)
		{
			spawnTime = spawnTime - timeReduction;
			spawnTime = Mathf.Clamp(spawnTime, lowestSpawnTime, highestSpawnTime);
			nextReduction = nextReduction + timeInterval;
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
	void GoldObjectSpawner()
	{
		if(goldKokosnootCounter >= 5)
		{
			CreateGoudenKokosnoot(CreateRandomVector());
			goldKokosnootCounter=0;
		}
		if(goldMelonCounter >= 5)
		{
			CreateGoldenMelon(CreateRandomVector());
			goldMelonCounter=0;
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
		kokosnootCounter++;
		g.name = "Kokosnoot"+kokosnootCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}
	void CreateGoudenKokosnoot(Vector3 position)
	{
		GameObject g = CreateFallingObject(GoudenKokosnootPrefab, position);
		kokosnootCounter++;
		g.name = "GoudenKokosnoot"+kokosnootCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}

	void CreateMelon(Vector3 position)
	{
		GameObject g = CreateFallingObject(MeloenPrefab, position);
		kokosnootCounter++;
		melonCounter++;
		g.name = "Meloen"+melonCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}
	void CreateGoldenMelon(Vector3 position)
	{
		GameObject g = CreateFallingObject(GoudenMeloenPrefab, position);
		kokosnootCounter++;
		g.name = "GoudenMeloen"+melonCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}

	GameObject CreateFallingObject(GameObject fallingObject, Vector3 position)
	{
		GameObject g = (GameObject) Instantiate(fallingObject, position, Quaternion.identity);
		return g;
	}
}
