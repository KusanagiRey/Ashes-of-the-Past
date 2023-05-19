using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region Public Variables
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    #endregion

    #region Private Variables
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    private float damage;
    #endregion

    void Awake()
    {
        intTimer = timer;
        SelectTarget();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(!attackMode)
        {
            Move();
        }

        if(!InsideoLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("MelleAtack"))
        {
            SelectTarget();
        }

        if(inRange)
        {
            EnemyLogic();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance > attackDistance)
        {
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if(cooling)
        {
            Cooldown();
            anim.SetBool("isAttacking", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("MelleAtack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("isAttacking", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        attackMode = false;
        anim.SetBool("isAttacking", false);
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private bool InsideoLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        timer = intTimer;
        cooling = false;

        if (distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }else{
            target = rightLimit;
        }

        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }else{
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }
    }
}
