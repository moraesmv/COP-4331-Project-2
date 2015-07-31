using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;

	public bool isPaused = false;

	public GameObject PauseManuCanvas;

	void Update()
	{
		if(isPaused)
		{
			PauseManuCanvas.SetActive(true);
			Time.timeScale = 0f;
		}
		else
		{
			PauseManuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if(Input.GetKeyDown(KeyCode.P))
		{
			isPaused = !isPaused;
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}
	}
	
	public void MainMenu()
	{
		Application.LoadLevel(mainMenu);
	}
	
	public void Resume()
	{
		isPaused = false;
	}
	
	public void QuitGame()
	{
		Application.Quit();
	}
}
