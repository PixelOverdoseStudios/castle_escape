using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, jumpForce, attackTimer;
    [SerializeField] LayerMask groundMask;

    private Rigidbody2D rig;
    private SpriteRenderer sr;
    private AnimationHandler animHandler;
    private RaycastHit2D groundCast;
    private CapsuleCollider2D capCol2D;
    private float nextFireTime = 0;
    private AudioPlayer audioPlayer;

    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        capCol2D = GetComponent<CapsuleCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        animHandler = GetComponent<AnimationHandler>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rig.velocity = new Vector2 (moveInput * moveSpeed, rig.velocity.y);

        if (rig.velocity.x < 0f)
        {
            transform.localScale = new Vector3 (-1f, 1f, 1f);
        }
        else if (rig.velocity.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    void Update()
    {
        HandleAnimation();
        HandleJumping();
        Attack();
    }

    void HandleAnimation()
    {
        animHandler.PlayRun(Mathf.Abs((int)rig.velocity.x));
        animHandler.PlayJumpAndFall((int)rig.velocity.y);
    }
    
    void HandleJumping()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                Jump();
            }
        }
    }

    bool IsGrounded()
    {
        groundCast = Physics2D.BoxCast(capCol2D.bounds.center, capCol2D.bounds.size, 0f, Vector2.down, 0.25f, groundMask);
        return groundCast.collider != null;
    }

    void Jump()
    {
        rig.velocity = Vector2.up * jumpForce;
    }

    void Attack()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animHandler.SwingSword();
                audioPlayer.PlayerSwingSword();
                nextFireTime = Time.time + attackTimer;
            }
        }
    }
}
