using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public Text counterText;

	public static float timeToLevelComplete;

	public float seconds, minutes;

	// Use this for initialization
	void Start () {
	
		counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
		timeToLevelComplete = Time.timeSinceLevelLoad;
		minutes = (int)(timeToLevelComplete / 60f);
		seconds = (int)(timeToLevelComplete % 60f);
		counterText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

	}

	public static float GetTime()
	{
		return timeToLevelComplete;
	}
}
