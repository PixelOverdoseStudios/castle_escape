using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement Parameters")]
    [SerializeField] private float enemyMoveSpeed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header ("Animator")]
    [SerializeField] private Animator animator;

    void Awake()
    {
        initScale = enemy.localScale;
    }

    void Start()
    {
        leftEdge.SetParent(null);
        rightEdge.SetParent(null);
    }

    void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    void OnDisable()
    {
        animator.SetBool("moving", false);
    }

    void DirectionChange()
    {
        animator.SetBool("moving", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    void MoveInDirection (int direction)
    {
        idleTimer = 0;

        animator.SetBool("moving", true);

        enemy.localScale = new Vector3 (Mathf.Abs(initScale.x) * direction, 
            initScale.y, initScale.z);

        enemy.position = new Vector3 (enemy.position.x + Time.deltaTime * direction * enemyMoveSpeed, 
            enemy.position.y, enemy.position.z);
    }
}
