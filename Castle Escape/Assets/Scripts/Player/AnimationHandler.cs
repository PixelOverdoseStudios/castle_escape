using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayRun(int run)
    {
        animator.SetInteger("run", run);
    }

    public void PlayJumpAndFall (int jump)
    {
        animator.SetInteger("jump", jump);
    }

    public void SwingSword()
    {
        animator.SetTrigger("attack");
    }

    public void PlayerDeath()
    {
        animator.SetTrigger("die");
    }
}
