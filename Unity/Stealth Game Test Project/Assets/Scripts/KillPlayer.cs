using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
	public TriesManager triesManager;
	public TimeManager timeManager;



	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		triesManager = FindObjectOfType<TriesManager>();
		timeManager = FindObjectOfType<TimeManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.name == "Player" && triesManager.dead == false)
			{
			    triesManager.dead = true;
				timeManager.StopTimer();
				triesManager.Captured();
				levelManager.RespawnPlayer();
			}
	}
}
