using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHitBox : MonoBehaviour
{
    [SerializeField] Health health;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(1);
            //Invoke("ReloadLevel", 2f);
        }
    }

    //void ReloadLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
