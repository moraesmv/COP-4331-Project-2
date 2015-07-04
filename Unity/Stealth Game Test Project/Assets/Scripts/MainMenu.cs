using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string startLevel;

	public string continuation;

	public int playerTries;

	public int playerScore;

	public void NewGwme()
	{
		PlayerPrefs.SetInt("PlayerTries", playerTries);
		PlayerPrefs.SetInt("PlayerScore", playerScore);
		Application.LoadLevel(startLevel);
	}

	public void Continuaton()
	{
		//todo continue
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
