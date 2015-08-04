using UnityEngine;
using System.Collections;

public class CodecScript : MonoBehaviour {

	public int level;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;
	public AudioClip clip5;
	public AudioClip callEnd;


	// Use this for initialization
	void Start () {
		level = PlayerPrefs.GetInt("Level");
		AudioSource audio = GetComponent<AudioSource>();
		if (level==1)
			audio.clip = clip1;
		else if (level==2)
			audio.clip = clip2;
		else if (level==3)
			audio.clip = clip3;
		else if (level==4)
			audio.clip = clip4;
		else //if (level==5)
			audio.clip = clip5;

		audio.Play();
		audio.Play(44100);

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = clip1;
			audio.Play();
			audio.Play(44100);
			//PlayerPrefs.SetInt("Level", level);
			//level = PlayerPrefs.GetInt("Level");
			if (level==1)
				Application.LoadLevel("Level_1");
			else if (level==2)
				Application.LoadLevel("Level_2");
			else if (level==3)
				Application.LoadLevel("Level_3");
			else if (level==4)
				Application.LoadLevel("Level_4");
			else //if (level==5)
				Application.LoadLevel("Level_5");



			
		}


	}
}
