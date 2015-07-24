using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;

	Text text;

	void Start()
	{
		text = GetComponent<Text>();
		score = PlayerPrefs.GetInt("PlayerScore");
	}

	void Update()
	{
		if (score < 0)
		{
			PlayerPrefs.SetInt("PlayerScore", 0);
			score = 0;
		}

		text.text = "" + score;
	}

	public static void AddPoints(int pointsToAdd)
	{

		score += pointsToAdd;
		PlayerPrefs.SetInt("PlayerScore", score);

	}

	public static void Reset()
	{
		PlayerPrefs.SetInt("PlayerScore", 0);
		score = 0;
	}

	public void HighscoreUpdate () { 

	if(PlayerPrefs.HasKey("Score"))
	{
		Debug.Log( "Current HighScore " + PlayerPrefs.GetInt("Score") );            
		if( score > PlayerPrefs.GetInt("Score"))
		{ 
			Debug.Log("Saved new score value " + score );
			PlayerPrefs.SetInt ("Score", score); 
		}
	}
	else
	{  
		Debug.Log( "Created new key at PlayerPref for score " +score );
		PlayerPrefs.SetInt ("Score", score);
	}
		//NewScore ();
	}

	
	public void NewScore () {
		

	}
}
