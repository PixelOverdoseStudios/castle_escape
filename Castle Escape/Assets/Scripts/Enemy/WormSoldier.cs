using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSoldier : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private Vector3 tempPos;
    private Vector3 tempScale;

    private bool moveLeft;

    [SerializeField] LayerMask groundLayer;

    [SerializeField] Transform groundCheckPos;

    private RaycastHit2D groundHit;

    void Awake()
    {
        if (Random.Range(0, 2) > 0)
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }
    }

    void Update()
    {
        HandleMovement();
        CheckForGround();
    }

    void HandleMovement()
    {
        tempPos = transform.position;
        tempScale = transform.localScale;

        if(moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -1f;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = 1f;
        }

        transform.position = tempPos;
        transform.localScale = tempScale;
    }

    void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.5f, groundLayer);

        if (!groundHit)
        {
            moveLeft = !moveLeft;
        }

        Debug.DrawRay (groundCheckPos.position, Vector2.down * 0.5f, Color.red);
    }
}
