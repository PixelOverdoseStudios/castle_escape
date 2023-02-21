using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private CapsuleCollider2D capCol;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player is sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                animator.SetTrigger("meleeAttack");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(capCol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(capCol.bounds.size.x * range, capCol.bounds.size.y, capCol.bounds.size.z), 
            0, Vector2.left, 0, playerLayer);

        return hit.collider !=null;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(capCol.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(capCol.bounds.size.x * range, capCol.bounds.size.y, capCol.bounds.size.z));
    }
}
