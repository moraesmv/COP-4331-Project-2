using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text counterText;

	public static float timeToLevelComplete;
	public bool timeActive = true;

	public float seconds, minutes;

	// Use this for initialization
	void Start () {
	
		counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {

		if(timeActive)
		{
			timeToLevelComplete = Time.timeSinceLevelLoad;
			minutes = (int)(timeToLevelComplete / 60f);
			seconds = (int)(timeToLevelComplete % 60f);
			counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
			PlayerPrefs.SetInt("PlayerTime", (int)timeToLevelComplete);
		}
	}

	public static float GetTime()
	{
		return timeToLevelComplete;
	}

	public void StopTimer () {

		timeActive     = false;
	}

	public void HighscoreUpdate () { 
		
		if(PlayerPrefs.HasKey("Time"))
		{
			Debug.Log( "Current timer " + PlayerPrefs.GetInt("Time") );            
			if( timeToLevelComplete > PlayerPrefs.GetInt("Time"))
			{ 
				Debug.Log("Saved new timer value " + timeToLevelComplete );
				PlayerPrefs.SetInt ("Time", (int)timeToLevelComplete); 
			}
		}
		else
		{  
			Debug.Log( "Created new key at PlayerPref for timer " +timeToLevelComplete );
			PlayerPrefs.SetInt ("Time", (int)timeToLevelComplete);
		}
		}
		
}
