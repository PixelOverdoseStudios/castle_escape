using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpike : MonoBehaviour
{
    private Rigidbody2D rig;
    [SerializeField] LayerMask collisionLayer;
    [SerializeField] float fallingSpeed;
    [SerializeField] float detectionLength;
    [SerializeField] float secondsToLiveAfterFalling;
    private RaycastHit2D playerCast;

    private bool collidedWithPlayer;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckForPlayerCollision();
    }

    void CheckForPlayerCollision()
    {
        if (collidedWithPlayer)
            return;

        playerCast = Physics2D.Raycast(transform.position, Vector2.down, detectionLength, collisionLayer);
        
        Debug.DrawRay (transform.position, Vector2.down * detectionLength, Color.red);

        if (playerCast.collider != null)
        {
            collidedWithPlayer = true;
            rig.gravityScale = fallingSpeed;
            Destroy(gameObject, secondsToLiveAfterFalling);

        }
    }
}
