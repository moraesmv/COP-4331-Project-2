using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriesManager : MonoBehaviour {
	
	public static int tries;
	public int maxTries = 3;
	
	Text text;

	private LevelManager levelManager;
	private ScoreManager scoreManager;
	private TimeManager timeManager;

	public bool gameOver;
	public bool dead = false;

	public GameObject gameOverScreen;
	public GameObject currentLevel;
	public GameObject currentTime;
	public GameObject currentScore;

	private CurrentLevel levelCurrent;
	private CurrentScore scoreCurrent;
	private CurrentTime timeCurrent;

	public PlayerController2 player;

	public string mainMenu;

	public float waitAfterGameOver;

	void Start()
	{

		levelCurrent = currentLevel.GetComponent<CurrentLevel> ();
		scoreCurrent = currentScore.GetComponent<CurrentScore> ();
		timeCurrent = currentTime.GetComponent<CurrentTime> ();
		text = GetComponent<Text>();
		tries = PlayerPrefs.GetInt("PlayerTries");
		player = FindObjectOfType<PlayerController2>();
		levelManager = FindObjectOfType<LevelManager>();
		gameOver = false;
	}
	
	void Update()
	{
		if (tries < 1 && !gameOver)
		{
			gameOver = true;
		}
		if (gameOver)
		{
			levelCurrent.txt.text = "leveltest";
			scoreCurrent.txt.text = "scoretest";
			timeCurrent.txt.text = "timetest";
			gameOverScreen.SetActive(true);
			player.gameObject.SetActive(false);
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0)
		{
			PlayerPrefs.SetString("levelGameOver", Application.loadedLevelName);
			Reset();
			Application.LoadLevel(mainMenu);
		}
		text.text = "X " + tries;
	}
	
	public void Captured()
	{
		if(!dead)
		{
			tries--;
			PlayerPrefs.SetInt("PlayerTries", tries);
			dead = true;
		}
	}

	public void lifeUp()
	{
		tries++;
		PlayerPrefs.SetInt("PlayerTries", tries);
	}

	public void Reset()
	{
		PlayerPrefs.SetInt("PlayerTries", maxTries);
	}
	

}
