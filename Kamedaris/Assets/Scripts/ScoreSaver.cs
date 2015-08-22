using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScoreSaver : MonoBehaviour {

	private const string SAVE_PATH = "data/Data.txt";
	private static string path =""; 


	[System.Serializable]
	public class Scores
	{
		public Scores(string pl, float sc){
			plName = pl;
			score = sc;
		}

		public string plName = "Player";
		public float score = 0;
	}
	
	public static List<Scores> scorings = new List<Scores>();
	public static string[] pScorings = new string[10];

	public void Awake(){
		path = Application.dataPath + "/data/Data.txt";
		if(File.Exists(path))
		{
			SetList();
		}
		if(!Directory.Exists(Application.dataPath +"/data"))
		{
			Directory.CreateDirectory(Application.dataPath + "/data");//unity doesn't compile a map automaticly, so this piece of code does it.
		}
	}

	public static void SetData()
	{
		if (File.Exists(path))//does it already exists?
		{ 
			File.Delete(path);
		}
		
		using (StreamWriter sw = new StreamWriter(path))
		{
			foreach (Scores it in scorings)
			{
				//Debug.Log(it.score);
				sw.WriteLine(it.plName);
				sw.WriteLine(it.score.ToString());
			}
		}
	}

	public static void SetList()
	{
		scorings.Clear();
		
		string[] content = File.ReadAllLines(path);
		
		for (int i = 0; i < content.Length; i = i + 2)
		{
			Scores newStuff = new Scores(content[i],float.Parse(content[i + 1]));
			scorings.Add(newStuff);
		}
		
	}

	public static List<Scores> ListNames(Scores nScore)
	{
		scorings.Add(nScore);//adding the score the player just had
		var rOrder =//sort the scores from high to low
			from score in scorings
				orderby score.score
				descending
				select score;



		List<Scores> ListName = new List<Scores>();//temporary list
		
		int i = 0;
		foreach (var sc in rOrder)
		{
			pScorings[i] = sc.score.ToString();
			Scores temp = new Scores(sc.plName,sc.score);
			ListName.Add(temp);

			i++;
			if (i > 9)
				break;
		}
		return ListName;
	}
}
