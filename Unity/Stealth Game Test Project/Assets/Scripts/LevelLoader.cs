using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	private bool playerInZone;
	public string levelToLoad;
	public string currentLevel;
	public int timeInLevel;

	// Use this for initialization
	void Start ()
	{
		playerInZone = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInZone) {

			Application.LoadLevel(levelToLoad);
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player") {
			currentLevel = levelToLoad;
			PlayerPrefs.SetString("LevelLoaded", currentLevel);
			timeInLevel = (int)TimeManager.GetTime();
			PlayerPrefs.SetInt("TimeInLevel", timeInLevel);
			playerInZone = true;
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "Player") {
			playerInZone = false;
		}

	}
}
