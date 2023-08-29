using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    [SerializeField] float currentHealth;

    public string targetTag;

    
    private bool isCombat;
    private bool canMove;

    private UnitStat unitstat;
    private Animator anim;

    

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        unitstat = GetComponent<UnitStat>();
        if (gameObject.tag == "Player")
            targetTag = "Enemy";
        else
            targetTag = "Player";

        currentHealth = unitstat.unit_health;
    }

    void Update()
    {
        canMove = true;
        // ���� ���� �ƴ϶�� ���� �ӵ��� �̵��Ѵ�.
        Move();

        // ���� ü���� 0�̸� ���
        Die();

    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void Move()
    {
        if (!isCombat)
        {
            transform.position += new Vector3(-transform.localScale.x * Time.deltaTime * unitstat.unit_move_speed, 0, 0);
            anim.SetFloat("RunState", 0.26f);
        }

    }


   
    private void AttackProcess()
    {
        isCombat = true;
        anim.SetFloat("RunState", 0);
        anim.SetBool("Attack", true);
        anim.SetFloat("NormalState", 0);
    }

    public void Attack(Transform target)
    {
        UnitCombat targetunit = target.GetComponent<UnitCombat>();
        targetunit.Hit(unitstat.unit_attack_amount);
    }

    public void Hit(float damageAmount)
    {
        float trueDamage = damageAmount - unitstat.unit_defense;
        currentHealth -= trueDamage;
    }

    public void AttackCancle()
    {
        if (!canMove) return;
        isCombat = false;
        anim.SetBool("Attack", false);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            // ����, ���� ��� ����
            AttackProcess();

            canMove = false;
        }
    }

    

}