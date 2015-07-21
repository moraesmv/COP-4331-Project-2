using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public int playerTries;

	public int playerScore;
	private LevelManager levelManager;

	public void NewGwme()
	{
		PlayerPrefs.SetInt("PlayerTries", playerTries);
		PlayerPrefs.SetInt("PlayerScore", playerScore);
		Application.LoadLevel(startLevel);
	}

	public void Continuaton()
	{
		//levelManager.ContinueGame();
		Application.LoadLevel(PlayerPrefs.GetString("levelGameOver"));
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
