using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TriesManager : MonoBehaviour {
	
	public static int tries;
	public int maxTries = 3;
	public bool dead = false;
	
	public MyChangeableText health;
	public MyChangeableText currentLevel;
	public MyChangeableText currentTime;
	public MyChangeableText currentScore;
	
	private TimeManager timeManager;


	public bool gameOver;

	public GameObject gameOverScreen;

	public PlayerController2 player;

	public string mainMenu;
	public Button myselfButton;

	public float waitAfterGameOver;

	void Start()
	{
		timeManager = FindObjectOfType<TimeManager>();
		myselfButton = GetComponent<Button>();
		dead = false;
		tries = PlayerPrefs.GetInt("PlayerTries");
		player = FindObjectOfType<PlayerController2>();
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
			currentTime.ChangeMyText( "" + PlayerPrefs.GetInt("PlayerTime"));
			currentScore.ChangeMyText( "" + PlayerPrefs.GetInt("PlayerScore"));
			currentLevel.ChangeMyText( "" + PlayerPrefs.GetInt("Level"));
			gameOverScreen.SetActive(true);
			player.enabled = false;
			player.GetComponent<Renderer>().enabled = false;
			player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			timeManager.timeActive = false;

			
		}
		
		health.ChangeMyText( "X " + tries);
	}
	
	public void Captured()
	{
			tries--;
		if (tries < 0)
		{
			tries = 0;
		}
			PlayerPrefs.SetInt("PlayerTries", tries);
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
