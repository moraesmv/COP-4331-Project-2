using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	private bool playerInZone;
	public string levelToLoad;
	public string currentLevel;
	public int timeInLevel;
	public int levelNumber;

	// Use this for initialization
	void Start ()
	{
		playerInZone = false;
		levelNumber = LevelToNumber(currentLevel);
		PlayerPrefs.SetInt("Level", levelNumber );
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInZone) {
			levelNumber = LevelToNumber(levelToLoad);
			PlayerPrefs.SetInt("Level", levelNumber );
			Application.LoadLevel("Codec");
		}

	}

	public void LoadStart()
	{
		Application.LoadLevel("TitleMenu");
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			levelNumber++;
			PlayerPrefs.SetInt("Level", levelNumber);
			playerInZone = true;
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "Player") {
			playerInZone = false;
		}

	}

	public int LevelToNumber(string ltl)
	{
		switch(ltl)
		{
		case "Level_1":
			return 1;
		case "Level_2":
			return 2;
		case "Level_3":
			return 3;
		case "Level_4":
			return 4;
		case "Level_5":
			return 5;
		default:
			return 1;
		}
	}


}
