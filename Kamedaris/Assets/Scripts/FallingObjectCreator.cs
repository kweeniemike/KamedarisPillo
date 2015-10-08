using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public bool startTimerRunning = false;
	public int countdownSeconds = 5;
	public Text countdownText;
	private enum SpawnLocation{Left, Center, Right};
	public float maxHorizontalForce;

	// Use this for initialization
	void Start () {
		StartCoroutine (startTimerCountdown(countdownSeconds, countdownText));
		nextReduction = timeInterval;
		startTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update () {
		if (Score.gameEnded) {
			return;
		}
		//KeyInput();
		if (!startTimerRunning) {
			SpawnOnTimer ();
			GoldObjectSpawner ();
		}
	}
	void KeyInput()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			CreateMelon(CreateRandomVector(),SpawnLocation.Left,new Vector3(maxHorizontalForce,0,0));
		}
		if (Input.GetKeyDown(KeyCode.K))
		{
			CreateKokosnoot(CreateRandomVector(),SpawnLocation.Right,new Vector3(maxHorizontalForce,0,0));
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
			SpawnLocation sp = (SpawnLocation)Random.Range(0,3);
			int r = Random.Range(0,2);
			if(r == 1)
			{
				CreateMelon(CreateRandomVector(),sp,CreateRandomForce());
			}
			else{
				CreateKokosnoot(CreateRandomVector(),sp,CreateRandomForce());
			}
			lastSpawnTime = currentTime;
		}
	}
	void GoldObjectSpawner()
	{
		if(goldKokosnootCounter >= 5)
		{
			SpawnLocation sp = (SpawnLocation)Random.Range(0,3);
			CreateGoudenKokosnoot(CreateRandomVector(),sp,CreateRandomForce());
			goldKokosnootCounter=0;
		}
		if(goldMelonCounter >= 5)
		{
			SpawnLocation sp = (SpawnLocation)Random.Range(0,3);
			CreateGoldenMelon(CreateRandomVector(),sp,CreateRandomForce());
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

	Vector3 CreateRandomForce()
	{
		float randomX = Random.Range(0, maxHorizontalForce);
		Vector3 vector = new Vector3(randomX,0,0);
		return vector;
	}

	void CreateKokosnoot(Vector3 position, SpawnLocation s, Vector3 force)
	{
		if (s == SpawnLocation.Left)
			position = new Vector3 (minXPosition, maxYPosition, 0);
		else if (s == SpawnLocation.Right) {
			position = new Vector3 (maxXPosition, maxYPosition, 0);
			force = -force;
		} else
			force = Vector3.zero;
		GameObject g = CreateFallingObject(KokosnootPrefab, position);
		kokosnootCounter++;
		Rigidbody rb = g.GetComponent<Rigidbody> ();
		rb.AddForce (force);
		g.name = "Kokosnoot"+kokosnootCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}
	void CreateGoudenKokosnoot(Vector3 position, SpawnLocation s, Vector3 force)
	{
		if (s == SpawnLocation.Left)
			position = new Vector3 (minXPosition, maxYPosition, 0);
		else if (s == SpawnLocation.Right) {
			position = new Vector3 (maxXPosition, maxYPosition, 0);
			force = -force;
		} else
			force = Vector3.zero;
		GameObject g = CreateFallingObject(GoudenKokosnootPrefab, position);
		kokosnootCounter++;
		Rigidbody rb = g.GetComponent<Rigidbody> ();
		rb.AddForce (force);
		g.name = "GoudenKokosnoot"+kokosnootCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}

	void CreateMelon(Vector3 position, SpawnLocation s, Vector3 force)
	{
		if (s == SpawnLocation.Left)
			position = new Vector3 (minXPosition, maxYPosition, 0);
		else if (s == SpawnLocation.Right) {
			position = new Vector3 (maxXPosition, maxYPosition, 0);
			force = -force;
		} else
			force = Vector3.zero;
		GameObject g = CreateFallingObject(MeloenPrefab, position);
		melonCounter++;
		Rigidbody rb = g.GetComponent<Rigidbody> ();
		rb.AddForce (force);
		g.name = "Meloen"+melonCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}
	void CreateGoldenMelon(Vector3 position, SpawnLocation s, Vector3 force)
	{
		if (s == SpawnLocation.Left)
			position = new Vector3 (minXPosition, maxYPosition, 0);
		else if (s == SpawnLocation.Right) {
			position = new Vector3 (maxXPosition, maxYPosition, 0);
			force = -force;
		} else
			force = Vector3.zero;
		GameObject g = CreateFallingObject(GoudenMeloenPrefab, position);
		melonCounter++;
		Rigidbody rb = g.GetComponent<Rigidbody> ();
		rb.AddForce (force);
		g.name = "GoudenMeloen"+melonCounter;
		g.transform.parent = this.transform;
		g.transform.Rotate(Random.Range(0,360),90,90);
	}

	GameObject CreateFallingObject(GameObject fallingObject, Vector3 position)
	{
		GameObject g = (GameObject) Instantiate(fallingObject, position, Quaternion.identity);
		return g;
	}

	IEnumerator startTimerCountdown(int seconds, Text countdown)
	{
		startTimerRunning = true;
		int secondsCounted = 0;
		while (secondsCounted < seconds) {
			countdown.text = (seconds - secondsCounted).ToString();
			secondsCounted ++;
			yield return new WaitForSeconds(1);
		}
		startTimerRunning = false;
		countdown.text = "";
		secondsCounted = 0;
		SoundManager.ToggleMainTheme (true);
	}
}
