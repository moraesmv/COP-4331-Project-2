using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject checkPoint;

	private PlayerController2 player;

	public GameObject deathParticle;
	public GameObject respawnParticle;
	public int pointPenaltyDeath;

	public float respawnDelay;

	public TriesManager triesManager;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController2>();
		triesManager = FindObjectOfType<TriesManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer()
	{
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		ScoreManager.AddPoints(-pointPenaltyDeath);
		//todo gameover
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.enabled = true;
		player.GetComponent<Renderer>().enabled = true;
		player.transform.position = checkPoint.transform.position;
		Instantiate(respawnParticle, checkPoint.transform.position, checkPoint.transform.rotation);

	}

}
