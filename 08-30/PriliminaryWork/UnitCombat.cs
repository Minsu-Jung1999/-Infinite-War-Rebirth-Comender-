using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(UnitStat))]
public class UnitCombat : MonoBehaviour
{
   

    [SerializeField] float currentHealth;
    [SerializeField] float damageNumberSpawnY = 1;


    [Header("Weapon Types")]
    [SerializeField] bool isNormal;
    [SerializeField] bool isBow;
    [SerializeField] bool isMagic;
    [Space]

    [SerializeField] Example ex;

    public bool isHit;
    public string targetTag;
    public int direction;

    private bool isCombat;
    private UnitStat unitstat;
    private Animator anim;


    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        unitstat = GetComponent<UnitStat>();
        if (gameObject.tag == "Player")
        {
            targetTag = "Enemy";
            direction = 1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            targetTag = "Player";
            direction = -1;
        }

        currentHealth = unitstat.unit_health;
    }

    void Update()
    {
        // 전투 중이 아니라면 일정 속도로 이동한다.
        Move();

        // 현재 체력이 0이면 사망
        Die();

    }


    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    //[HideInInspector]
    private float WeaponType()
    {
        if (isBow) return 0.5f;
        else if (isMagic) return 1f;
        return 0;   // normal로 간주
    }

    private void Move()
    {
        if (!isCombat)
        {
            transform.position += new Vector3(Time.deltaTime * unitstat.unit_move_speed * direction, 0, 0);
            anim.SetFloat("RunState", 0.26f);
        }
    }
   
    private void AttackProcess()
    {
        isCombat = true;
        anim.SetFloat("RunState", WeaponType());
        anim.SetBool("Attack", true);
        anim.SetFloat("AttackSpeed", unitstat.unit_attack_speed);
        anim.SetFloat("NormalState", WeaponType());
    }

    public void Attack(Transform target)
    {
        // Exception
        if(target == null)
        {
            AttackCancle();
            return;
        }
        UnitCombat targetunit = target.GetComponent<UnitCombat>();
        targetunit.Hit(unitstat.unit_attack_amount);

    }

    public void Hit(float damageAmount)
    {
        float trueDamage = damageAmount - unitstat.unit_defense;
        currentHealth -= trueDamage;
        Vector3 damageSpawnPosition = new Vector3(transform.position.x, transform.position.y + damageNumberSpawnY, 0);
        if(ex!=null)
            ex.DamageGeneration(damageSpawnPosition, trueDamage);
    }

    public void AttackCancle()
    {
        isCombat = false;
        anim.SetBool("Attack", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            // 공격, 공격 모션 실행
            AttackProcess();

        }
    }

    

}
 
