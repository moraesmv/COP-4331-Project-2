using UnityEngine;
using System.Collections;

public class ItemPickUp : MonoBehaviour {

	public int pointsToAdd;

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.GetComponent<PlayerController2>() == null)
			return;

		ScoreManager.AddPoints(pointsToAdd);

		Destroy(gameObject);
	}

}
