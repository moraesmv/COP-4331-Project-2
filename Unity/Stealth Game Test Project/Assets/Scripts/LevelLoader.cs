using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{

	private bool playerInZone;
	public string levelToLoad;
	public string currentLevel;
	public int timeInLevel;
	private int levelNumber = 1;

	// Use this for initialization
	void Start ()
	{
		playerInZone = false;
		PlayerPrefs.SetInt("Level", levelNumber);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerInZone) {

			Application.LoadLevel(levelToLoad);
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
}
