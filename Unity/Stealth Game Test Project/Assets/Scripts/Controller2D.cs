using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour 
{
    public int score = 0;

    public bool showDebug = true;

    // Three collision masks for types of objects we'll be interacting with
    public LayerMask collisionMask;
    public LayerMask treasureMask;
    public LayerMask doorMask;

    // Amount of rays used in each direction for raycast collision detection
    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    // Spacing between the raycast rays
    float horizontalRaySpacing;
    float verticalRaySpacing;

    // Rays will be fired from a small distance inside of the character to provide for better collision detection
    const float skinwidth = .015f;

    // Collider for the player object
    BoxCollider2D collider;

    // Originating points for raycasts
    RaycastOrigins raycastOrigins;

    Player player;

    void Start()
    {
        collider = GetComponent<BoxCollider2D> ();
        CalculateRaySpacing ();
        player = GameObject.FindObjectOfType<Player> ();
    }

    public void Move(Vector3 velocity)
    {
        UpdateRaycastOrigins ();

        HorizontalCollisions ( ref velocity );
        VerticalCollisions ( ref velocity );

        // Moves the character using the given velocity
        transform.Translate ( velocity );
    }


    /* input: BoxCollider of whatever treasure object the character hits
     * purpose: adds the treasure's value to the player's score and removes the treasure from the scene
     */
    void Pickup ( Collider2D collider )
    {
        Treasure treasure = collider.GetComponent<Treasure> ();
        GameObject gameObj = treasure.gameObject;

        score += treasure.value;
        GameObject.Destroy ( gameObj );
    }

    // Does the collision detection on the horizontal plane
    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign ( velocity.x );
        float rayLength = Mathf.Abs ( velocity.x ) + skinwidth;

        for(int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = ( directionX == -1 ) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * ( horizontalRaySpacing * i );
            
            // These return true if the player collides with any of the given layers
            RaycastHit2D hit = Physics2D.Raycast ( rayOrigin, Vector2.right * directionX, rayLength, collisionMask );
            RaycastHit2D hitTreasure = Physics2D.Raycast ( rayOrigin, Vector2.right * directionX, rayLength, treasureMask );
            RaycastHit2D hitDoor = Physics2D.Raycast ( rayOrigin, Vector2.right * directionX, rayLength, doorMask );

            if ( showDebug )
            {
                Debug.DrawRay ( rayOrigin, Vector2.right * directionX * rayLength, Color.red );
            }

            // If the player collides with anything labeled with the obstacle layer
            if(hit)
            {
                velocity.x = ( hit.distance - skinwidth ) * directionX;
                rayLength = hit.distance;
            }

            if(hitTreasure)
            {
                Pickup ( hitTreasure.collider );
            }

            if(hitDoor)
            {
                player.levelComplete = true;
            }
        }

    }

    // Does the collision detection on the vertical plane, for landing and walking and such
    void VerticalCollisions ( ref Vector3 velocity )
    {
        float directionY = Mathf.Sign ( velocity.y );
        float rayLength = Mathf.Abs ( velocity.y ) + skinwidth;

        for ( int i = 0; i < verticalRayCount; i++ )
        {
            Vector2 rayOrigin = ( directionY == -1 ) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * ( verticalRaySpacing * i + velocity.x );
            RaycastHit2D hit = Physics2D.Raycast ( rayOrigin, Vector2.up * directionY, rayLength, collisionMask );

            if ( showDebug )
            {
                Debug.DrawRay ( rayOrigin, Vector2.up * directionY * rayLength, Color.red );
            }

            if(hit)
            {
                velocity.y = ( hit.distance - skinwidth ) * directionY;
                rayLength = hit.distance;
            }
        }
    }

    // Updates the raycast origins...
    void UpdateRaycastOrigins()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand ( skinwidth * -2 );

        raycastOrigins.bottomLeft = new Vector2 ( bounds.min.x, bounds.min.y );
        raycastOrigins.bottomRight = new Vector2 ( bounds.max.x, bounds.min.y );
        raycastOrigins.topLeft = new Vector2 ( bounds.min.x, bounds.max.y );
        raycastOrigins.topRight = new Vector2 ( bounds.max.x, bounds.max.y );
    }
     
    void CalculateRaySpacing()
    {
        Bounds bounds = collider.bounds;
        bounds.Expand ( skinwidth * -2 );

        horizontalRayCount = Mathf.Clamp ( horizontalRayCount, 2, 50 );
        verticalRayCount = Mathf.Clamp ( verticalRayCount, 2, 50 );

        horizontalRaySpacing = bounds.size.y / ( horizontalRayCount - 1 );
        verticalRaySpacing = bounds.size.x / ( verticalRayCount - 1 );

    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
