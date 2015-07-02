using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour 
{
    public int score = 0;

    public bool showDebug = true;

    public LayerMask collisionMask;
    public LayerMask treasureMask;
    public LayerMask doorMask;

    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    const float skinwidth = .015f;
    BoxCollider2D collider;
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

        transform.Translate ( velocity );
    }

    void Pickup ( Collider2D collider )
    {
        Treasure treasure = collider.GetComponent<Treasure> ();
        GameObject gameObj = treasure.gameObject;

        score += treasure.value;
        GameObject.Destroy ( gameObj );
    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign ( velocity.x );
        float rayLength = Mathf.Abs ( velocity.x ) + skinwidth;

        for(int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = ( directionX == -1 ) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * ( horizontalRaySpacing * i );
            
            RaycastHit2D hit = Physics2D.Raycast ( rayOrigin, Vector2.right * directionX, rayLength, collisionMask );
            RaycastHit2D hitTreasure = Physics2D.Raycast ( rayOrigin, Vector2.right * directionX, rayLength, treasureMask );
            RaycastHit2D hitDoor = Physics2D.Raycast ( rayOrigin, Vector2.right * directionX, rayLength, doorMask );

            if ( showDebug )
            {
                Debug.DrawRay ( rayOrigin, Vector2.right * directionX * rayLength, Color.red );
            }

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
