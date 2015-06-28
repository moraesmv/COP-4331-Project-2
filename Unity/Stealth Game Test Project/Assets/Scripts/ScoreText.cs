using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

    Player player;
    float updateTime = .01f;
    float time;
	// Use this for initialization
	void Start () {
        player = GameObject.Find ( "Player" ).GetComponent<Player> ();
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        TextMesh guit = GameObject.Find ( "High Score Text" ).GetComponent<TextMesh> ();
        int s = int.Parse ( guit.text );

        if ( !player.levelComplete )
        {
            if ( Time.time > time && s < player.score )
            {
                s++;
                guit.text = "" + s;
                time = Time.time;
                time += updateTime;
            }
        }

        if(player.levelComplete)
        {
            guit.text = "LEVEL COMPLETE! SCORE: " + guit.text;
        }
	}
}
