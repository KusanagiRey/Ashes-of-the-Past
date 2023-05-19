using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Player")
        {
            if(collision.GetComponent<CharacterMovement>()._isRolling == false)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                collision.GetComponent<TimeStop>().StopTime(0.05f, 10, 0.1f);
            }
        }
    }
}
