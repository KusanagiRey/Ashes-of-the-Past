using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth = 20;
    public float currentHealth { get; private set; }

    private Animator anim;
    private bool dead;

    public GameObject character;
    [SerializeField] private int soulCost;

    private void Awake() 
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(!dead && currentHealth <= 0)
        {
            anim.SetTrigger("isDead");
            GetComponent<Enemy_Behaviour>().enabled = false;
            dead = true;
            Destroy(gameObject, 2f);
            Souls.instance.GiveSouls(soulCost);
        }  
    }
}
