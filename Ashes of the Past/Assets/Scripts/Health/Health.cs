using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 20;
    public float currentHealth { get; private set; }

    private Animator anim;
    private bool dead;

    public HealthBar healthBar;

    private void Awake() 
    {
        currentHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        healthBar.SetHealth(currentHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("getHit");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("isDead");
                GetComponent<CharacterMovement>().enabled = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                dead = true;
            }
            
        }
    }
}
