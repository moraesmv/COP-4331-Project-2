using UnityEngine;
using System.Collections;

public class Stairs : MonoBehaviour {

    BoxCollider2D collider;
    public Stairs linkedStairs;
    public bool UpStairs;
    PlayerController2 player;
    BoxCollider2D playerCollider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D> ();
    }

	void OnTriggerEnter2D (Collider2D collider)
    {
        player = collider.GetComponent<PlayerController2> ();
        if ( player == null )
        {
            return;
        }
        playerCollider = player.GetComponent<BoxCollider2D> ();
    }

    void Update()
    {
        if(playerCollider != null && playerCollider.IsTouching(collider) && player.grounded)
        {
            if ( Input.GetKeyDown ( KeyCode.UpArrow ) && UpStairs )
                player.transform.position = linkedStairs.transform.position;
            else if ( Input.GetKeyDown ( KeyCode.DownArrow ) && !UpStairs )
                player.transform.position = linkedStairs.transform.position;
        }
    }
}
