using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void Awake() 
    {
        damage = GetComponentInParent<CharacterStats>().damage;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }
}
