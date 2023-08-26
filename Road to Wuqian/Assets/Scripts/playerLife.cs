using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public HealthBar healthBar;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.SetHealth(health);
        if(health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        } 
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        health = 0;
        healthBar.SetHealth(health);
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
