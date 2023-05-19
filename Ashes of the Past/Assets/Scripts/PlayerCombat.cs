using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator _animator;
    public bool _isAttacking = false;
    public static PlayerCombat instance;

    private void Awake() 
    {
        instance = this;
    }

    void Start() 
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_isAttacking && StaminaBar.instance.currentStamina != 0)
        {
            StaminaBar.instance.UseStamina(5);
            _isAttacking = true;
        }
    }
}
