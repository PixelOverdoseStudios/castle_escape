using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private CapsuleCollider2D playerCapCol2D;
    private Rigidbody2D rb;
    private AnimationHandler animHandler;
    private AudioPlayer audioPlayer;

    private bool playerDead = false;

    void Awake()
    {
        playerCapCol2D = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        animHandler = GetComponent<AnimationHandler>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            animHandler.PlayerDeath();

            if (playerDead == false)
            {
                audioPlayer.PlayerDeathClip();
                playerDead = true;
            }
            
            GetComponent<PlayerController>().enabled = false;
            playerCapCol2D.enabled = false;
            rb.gravityScale = 0;

            Invoke("ReloadLevel", 3f);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
