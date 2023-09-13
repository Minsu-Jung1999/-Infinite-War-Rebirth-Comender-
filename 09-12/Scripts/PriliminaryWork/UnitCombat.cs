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
        public float currentCost;
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
    [SerializeField] private Material render;

    // 뇌절
    private GameObject sceneCenter;
    
    private UnitCurrentInfo currentInfo;
    private DropItemManager dropItemMG;
    private bool isCombat;
    private bool isDead;
    private Animator anim;


    private enum WEAPONTYPE { NORMAL = 0, BOW = 1, MAGIC = 2 }

    // 호출 될 때마다 실행 ( 큐에 담길 때, 스폰 될 때)
    private void OnEnable()
    {
        InitializeStat();

        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
        
        direction = gameObject.tag == "Player" ? 1 : -1;
        isDead = false;
        isCombat = false;
    }


    // 스폰 후 한 번만 실행
    private void Start()
    {
        InitializeProperty();
        print(transform.name + " : " + targetTag);
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
        currentInfo.currentCost = unitdata.cost;
    }

    private void InitializeProperty()
    {
        targetTag = gameObject.tag == "Player" ? "Enemy" : "Player";

        anim = gameObject.GetComponentInChildren<Animator>();
        dropItemMG = GetComponent<DropItemManager>();

        transform.localScale = new Vector3(transform.localScale.x * direction * (-1), transform.localScale.y, transform.localScale.z);
        

        sceneCenter = GameObject.Find("SceneCenter");
        
    }

    private void Update()
    {
        Move();
        DieProcess();
        hp = currentInfo.currentHealthPoint;
        if(transform.tag == "Player")
        {
            if(transform.position.x >= sceneCenter.transform.position.x )
            {
                GameManager.instance.isCenter = true;
                sceneCenter.transform.position += transform.right * Time.deltaTime * currentInfo.currentMoveSpeed;
                render.mainTextureOffset += (Vector2)transform.right * Time.deltaTime * currentInfo.currentMoveSpeed / 6;
            }
        }
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



    // EVENT Caller 에서 호출 될 함수
    public void Die()
    {
        anim.SetBool("Die", false);
        
        // Animation State 가 Exit를 거쳐서 Entry로 가야 이전 애니매이션에서 설정했던 Unit 회전, 위치 값이 초기화가 이루어진다. Entry로 안전하게 이동하기 위해 0.03초 쉬었다가 삭제해 준다.
        Invoke("DES", 0.03f);
    }

    private void DES()
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

        anim.SetFloat("AttackSpeed", currentInfo.currentAttackSpeed);
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
        if (!targetUnit)
        {
            print("Null 임");
            PlayerManager playermanager = target.GetComponent<PlayerManager>();
            playermanager.Hit(currentInfo.currentAttackAmount);
        }
        else
        {
            targetUnit.Hit(currentInfo.currentAttackAmount);
        }
    }

    public void Hit(float damageAmount)
    {
        if(!isDead)
        {
            float trueDamage = damageAmount - currentInfo.currentArmo;
            currentInfo.currentHealthPoint -= trueDamage;
            Vector3 damageSpawnPosition = new Vector3(transform.position.x, transform.position.y + damageNumberSpawnY, 0);
            if (ex != null)
                ex.DamageGeneration(damageSpawnPosition, trueDamage);
        }
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
        if(currentInfo.currentHealthPoint == 0)
        {
            return unitdata.hp;
        }
        return currentInfo.currentHealthPoint;
    }
    /* 현재 공격력을 반환 */
    public float GetCurrentAD()
    {
        if (currentInfo.currentAttackAmount == 0)
        {
            return unitdata.attackAmount;
        }
        return currentInfo.currentAttackAmount;
    }
    /* 현재 공격 속도를 반환 */
    public float GetCurrentAS()
    {
        if (currentInfo.currentAttackSpeed == 0)
        {
            return unitdata.attackSpeed;
        }
        return currentInfo.currentAttackSpeed;
    }
    /* 현재 방어력을 반환 */
    public float GetCurrentAR()
    {
        if (currentInfo.currentArmo == 0)
        {
            return unitdata.ar;
        }
        return currentInfo.currentArmo;
    }
    /* 현재 이동속도를 반환 */
    public float GetCurrentMS()
    {
        if (currentInfo.currentMoveSpeed == 0)
        {
            return unitdata.ms;
        }
        return currentInfo.currentMoveSpeed;
    }
    /* 현재 공격 범위를 반환 */
    public float GetCurrentAttackRange()
    {
        if (currentInfo.currentAttackRange == 0)
        {
            return unitdata.ar;
        }
        return currentInfo.currentAttackRange;
    }
    /* 현재 캐릭터 코스트를 반환 */
    public float GetCurrentCost()
    {
        if (currentInfo.currentCost == 0)
        {
            return unitdata.cost;
        }
        return currentInfo.currentCost;
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


    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
