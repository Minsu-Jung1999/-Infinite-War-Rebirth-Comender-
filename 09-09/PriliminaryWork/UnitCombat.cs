using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{

    public UnitData unitdata;

    public float hp;

    // 스텟 증가를 영구 증가와 일시적 증가를 나눠주기 위해서 현재 스텟 정보를 따로 저장하는 클래스를 구현.
    [Serializable]
    public class UnitCurrentInfo
    {
        public float currentHealthPoint;
        public float currentAttackAmount;
        public float currentAttackSpeed;
        public float currentAttackRange;
        public float currentAttackDelay;
        public float currentArmo;
        public float currentMoveSpeed;
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
    public bool canAttack;
    private Animator anim;
    private enum WEAPONTYPE { NORMAL = 0, BOW = 1, MAGIC = 2 }
    private float timer =0;

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
        currentInfo.currentAttackSpeed = unitdata.attackSpeed;
        currentInfo.currentArmo = unitdata.def;             
        currentInfo.currentMoveSpeed = unitdata.ms;
        currentInfo.currentAttackRange = unitdata.ar;
        currentInfo.currentAttackDelay = unitdata.attackDelay;

        anim.SetFloat("AttackSpeed", currentInfo.currentAttackSpeed);

    }

    private void InitializeUnit()
    {

        anim = gameObject.GetComponentInChildren<Animator>();
        dropItemMG = GetComponent<DropItemManager>();

        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        canAttack = true;

        targetTag = gameObject.tag == "Player" ? "Enemy" : "Player";
        direction = gameObject.tag == "Player" ? 1 : -1;
        transform.localScale = new Vector3(transform.localScale.x * direction * -1, transform.localScale.y, transform.localScale.z);

    }

    private void Update()
    {
        Move();
        DieProcess();
        hp = currentInfo.currentHealthPoint;
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
            if(dropItemMG)
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

    
    #region CurrentStat 반환
    /* 현재 체력을 반환 */
    public float GetCurrentHP()
    {
        if(currentInfo == null)
            InitializeStat();
        return currentInfo.currentHealthPoint;
    }
    /* 현재 공격력을 반환 */
    public float GetCurrentAD()
    {
        if (currentInfo == null)
            InitializeStat();
        return currentInfo.currentHealthPoint;
    }
    /* 현재 공격 속도를 반환 */
    public float GetCurrentAS()
    {
        if (currentInfo == null)
            InitializeStat();
        return currentInfo.currentAttackSpeed;
    }
    /* 현재 방어력을 반환 */
    public float GetCurrentAR()
    {
        if (currentInfo == null)
            InitializeStat();
        return currentInfo.currentArmo;
    }
    /* 현재 이동속도를 반환 */
    public float GetCurrentMS()
    {
        if (currentInfo == null)
            InitializeStat();
        return currentInfo.currentMoveSpeed;
    }
    /* 현재 공격 범위를 반환 */
    public float GetCurrentAttackRange()
    {
        if (currentInfo == null)
            InitializeStat();
        return currentInfo.currentAttackRange;
    }
    #endregion

    #region 현재 스탯 강화
    /* 현재 체력을 반환 */
    public void HPIncreasing(float amount)
    {
        currentInfo.currentHealthPoint += amount;
    }
    /* 현재 체력을 반환 */
    public void ADIncreasing(float amount)
    {
        currentInfo.currentAttackAmount += amount;
    }
    /* 현재 체력을 반환 */
    public void ASIncreasing(float amount)
    {
        currentInfo.currentAttackAmount+= amount;
    }
    /* 현재 체력을 반환 */
    public void ARIncreasing(float amount)
    {
        currentInfo.currentArmo += amount;
    }
    /* 현재 체력을 반환 */
    public void MSIncreasing(float amount)
    {
        currentInfo.currentMoveSpeed += amount;
    }

    #endregion

    private void OnEnable()
    {
        Debug.Log("Spawn");
    }

    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
