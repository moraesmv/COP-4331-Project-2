using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisPS;

	// Use this for initialization
	void Start () {
		thisPS = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisPS.isPlaying)
		{
			return;
		}

		Destroy (gameObject);
	}

	void OnBecameInvisible ()
	{
		Destroy (gameObject);
	}
}
