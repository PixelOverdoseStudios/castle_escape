using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBatV1 : MonoBehaviour
{
    [SerializeField] float moveSpeedHorizontal = 2f, moveSpeedVertical = -2f;

    [SerializeField] float horizontalMovementTreshold = 7f, verticalMovementTreshold = 4f;

    private float minX, maxX, minY, maxY;

    private Vector3 tempPos;

    private bool moveHorizontal = true;
    private bool moveVertical;

    private SpriteRenderer sr;

    void Awake()
    {
        minX = transform.position.x - horizontalMovementTreshold;
        maxX = transform.position.x + horizontalMovementTreshold;

        minY = transform.position.y - verticalMovementTreshold;
        maxY = transform.position.y + verticalMovementTreshold;

        if (Random.Range(0, 2) > 0)
        {
            moveVertical = true;
        }
        else
        {
            moveVertical = false;
        }

        if (Random.Range(0, 2) > 0)
        {
            moveSpeedHorizontal *= -1f;
        }

        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
    }

    void HandleHorizontalMovement()
    {
        if (moveHorizontal)
        {
            tempPos = transform.position;

            tempPos.x += moveSpeedHorizontal * Time.deltaTime;

            if (tempPos.x > maxX)
            {
                moveSpeedHorizontal = -Mathf.Abs(moveSpeedHorizontal);
            }

            if (tempPos.x < minX)
            {
                moveSpeedHorizontal = Mathf.Abs(moveSpeedHorizontal);
            }

            transform.position = tempPos;

            //flipping Sprite based on movement
            if (moveSpeedHorizontal < 0)
                sr.flipX = true;
            else if (moveSpeedHorizontal > 0)
                sr.flipX = false;
        }
    }

    void HandleVerticalMovement()
    {
        if (moveVertical)
        {
            tempPos = transform.position;

            tempPos.y += moveSpeedVertical * Time.deltaTime;

            if (tempPos.y > maxY)
            {
                moveSpeedVertical = -Mathf.Abs(moveSpeedVertical);
            }

            if (tempPos.y < minY)
            {
                moveSpeedVertical = Mathf.Abs(moveSpeedVertical);
            }

            transform.position = tempPos;
        }
    }
}
