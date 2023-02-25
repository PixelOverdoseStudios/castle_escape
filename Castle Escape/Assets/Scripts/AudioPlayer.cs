using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip playerSwingSwordClip;
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] AudioClip enemySwingSwordClip;
    [SerializeField] AudioClip enemyDeathClip;

    public void PlayerSwingSword()
    {
        if(playerSwingSwordClip != null)
        {
            AudioSource.PlayClipAtPoint(playerSwingSwordClip, Camera.main.transform.position, 1f);
        }
    }
    public void PlayerDeathClip()
    {
        if (playerDeathClip != null)
        {
            AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, 1f);
        }
    }

    public void EnemySwingSword()
    {
        if (enemySwingSwordClip != null)
        {
            AudioSource.PlayClipAtPoint(enemySwingSwordClip, Camera.main.transform.position, 1f);
        }
    }

    public void EnemyDeathClip()
    {
        if (enemyDeathClip != null)
        {
            AudioSource.PlayClipAtPoint(enemyDeathClip, Camera.main.transform.position, 1f);
        }
    }
}
