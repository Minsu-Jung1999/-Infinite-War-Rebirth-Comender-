using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{

    public UnitData unitdata;

    // ���� ������ ���� ������ �Ͻ��� ������ �����ֱ� ���ؼ� ���� ���� ������ ���� �����ϴ� Ŭ������ ����.
    public class UnitCurrentInfo
    {
        public float currentHealthPoint;
        public float currentAttackAmount;
        public float currentAttackSpeed;
        public float currentArmo;
        public float currentMoveSpeed;
        public float currentAttackRange;
    }

    public bool isHit;
    public string targetTag;
    public int direction;

    [Header("Weapon Types")]
    [SerializeField] private bool isBow;
    [SerializeField] private bool isMagic;

    //[SerializeField] private float currentInfo.currentHealthPoint;
    [SerializeField] private float damageNumberSpawnY = 1;
    [SerializeField] private Example ex;

    private UnitCurrentInfo currentInfo;
    private DropItemManager dropItemMG;
    private bool isCombat;
    private bool isDead;
    private Animator anim;
    private enum WEAPONTYPE { NORMAL = 0, BOW = 1, MAGIC = 2 }


    private void Start()
    {
        InitializeUnit();
        InitializeStat();
    }

    private void InitializeStat()
    {
        currentInfo = new UnitCurrentInfo();
        currentInfo.currentHealthPoint = unitdata.hp;
        currentInfo.currentAttackAmount = unitdata.attackAmount;
        currentInfo.currentAttackSpeed = unitdata.ms;
        currentInfo.currentArmo = unitdata.def;
        currentInfo.currentMoveSpeed = unitdata.ms;
        currentInfo.currentAttackRange = unitdata.ar;
    }

    private void InitializeUnit()
    {

        anim = gameObject.GetComponentInChildren<Animator>();
        dropItemMG = GetComponent<DropItemManager>();

        targetTag = gameObject.tag == "Player" ? "Enemy" : "Player";
        direction = gameObject.tag == "Player" ? 1 : -1;
        transform.localScale = new Vector3(transform.localScale.x * direction * -1, transform.localScale.y, transform.localScale.z);

        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void Update()
    {
        Move();
        DieProcess();
    }


    private void Move()
    {
        if (!isCombat && !isDead)
        {
           
            transform.position += new Vector3(Time.deltaTime * currentInfo.currentMoveSpeed * direction, 0, 0);
            anim.SetFloat("RunSpeed", currentInfo.currentMoveSpeed);
            anim.SetFloat("RunState", 0.5f);
        }
    }

    public int WeaponType()
    {
        return isBow ? (int)WEAPONTYPE.BOW : (isMagic ? (int)WEAPONTYPE.MAGIC : (int)WEAPONTYPE.NORMAL);
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    private void DieProcess()
    {
        if (currentInfo.currentHealthPoint <= 0 && !isDead)
        {
            dropItemMG.ItemDrop();
            anim.SetBool("Die", true);
            isDead = true;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    private void AttackProcess()
    {
        isCombat = true;
        anim.SetFloat("RunState", 0);
        anim.SetBool("Attack", true);
        anim.SetFloat("AttackSpeed", currentInfo.currentAttackSpeed);
        anim.SetFloat("NormalState", WeaponType());
    }

    public void Attack(Transform target)
    {
        if (isDead) return;
        if (target == null)
        {
            AttackCancel();
            return;
        }
        UnitCombat targetUnit = target.GetComponent<UnitCombat>();
        targetUnit.Hit(currentInfo.currentAttackAmount);
    }

    public void Hit(float damageAmount)
    {
        float trueDamage = damageAmount - currentInfo.currentArmo;
        currentInfo.currentHealthPoint -= trueDamage;
        Vector3 damageSpawnPosition = new Vector3(transform.position.x, transform.position.y + damageNumberSpawnY, 0);
        if (ex != null)
            ex.DamageGeneration(damageSpawnPosition, trueDamage);
    }

    public void AttackCancel()
    {
        isCombat = false;
        anim.SetBool("Attack", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            AttackProcess();
        }
    }


    #region CurrentStat ��ȯ
    /* ���� ü���� ��ȯ */
    public float GetCurrentHP()
    {
        currentInfo = new UnitCurrentInfo();

        return currentInfo.currentHealthPoint;
    }
    /* ���� ���ݷ��� ��ȯ */
    public float GetCurrentAD()
    {
        InitializeStat();
        return currentInfo.currentHealthPoint;
    }
    /* ���� ���� �ӵ��� ��ȯ */
    public float GetCurrentAS()
    {
        InitializeStat();
        return currentInfo.currentAttackSpeed;
    }
    /* ���� ������ ��ȯ */
    public float GetCurrentAR()
    {
        InitializeStat();
        return currentInfo.currentArmo;
    }
    /* ���� �̵��ӵ��� ��ȯ */
    public float GetCurrentMS()
    {
        InitializeStat();
        return currentInfo.currentMoveSpeed;
    }
    #endregion

    #region ���� ���� ��ȭ
    /* ���� ü���� ��ȯ */
    public void HPIncreasing(float amount)
    {
        currentInfo.currentHealthPoint += amount;
    }
    /* ���� ü���� ��ȯ */
    public void ADIncreasing(float amount)
    {
        currentInfo.currentAttackAmount += amount;
    }
    /* ���� ü���� ��ȯ */
    public void ASIncreasing(float amount)
    {
        currentInfo.currentAttackAmount+= amount;
    }
    /* ���� ü���� ��ȯ */
    public void ARIncreasing(float amount)
    {
        currentInfo.currentArmo += amount;
    }
    /* ���� ü���� ��ȯ */
    public void MSIncreasing(float amount)
    {
        currentInfo.currentMoveSpeed += amount;
    }

    #endregion

    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
