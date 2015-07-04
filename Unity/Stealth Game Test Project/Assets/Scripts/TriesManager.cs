using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TriesManager : MonoBehaviour {
	
	public static int tries;
	//public int maxTries = 3;
	
	Text text;

	private LevelManager levelManager;

	public bool gameOver;

	public GameObject gameOverScreen;

	public PlayerController2 player;

	public string mainMenu;

	public float waitAfterGameOver;

	void Start()
	{
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
			gameOverScreen.SetActive(true);
			player.gameObject.SetActive(false);
			waitAfterGameOver -= Time.deltaTime;
		}

		if (waitAfterGameOver < 0)
		{
			Application.LoadLevel(mainMenu);
		}
		text.text = "X " + tries;
	}
	
	public void Captured()
	{
		tries--;
		PlayerPrefs.SetInt("PlayerTries", tries);
	}

	public void lifeUp()
	{
		tries++;
		PlayerPrefs.SetInt("PlayerTries", tries);
	}

	public void Reset()
	{
		tries = PlayerPrefs.GetInt("PlayerTries");
	}
	

}
