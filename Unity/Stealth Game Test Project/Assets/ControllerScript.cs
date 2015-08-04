using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	static public int theLevel;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		theLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
