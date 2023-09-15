using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Slider hpbar;
    [SerializeField] UnitData unitdata;
    [SerializeField] Example ex;
    [SerializeField] float exYPosition;
    private bool isDead;
    private float currentHP;

    private Animator anim;

    // 치졸한 방법인데...
    [SerializeField] private Material render;
    private Vector2 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        hpbar.maxValue = unitdata.hp;
        hpbar.value = unitdata.hp;
        currentHP = unitdata.hp;

        anim = GetComponentInChildren<Animator>();
        oldPos = render.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (oldPos.x < render.mainTextureOffset.x)
        {
            anim.SetBool("Run", true);
            oldPos.x = render.mainTextureOffset.x;
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
    
    

    public void Hit(float damageAmount)
    {
        if (!isDead)
        {
            float trueDamage = damageAmount;
            currentHP -= trueDamage;
            Vector3 damageSpawnPosition = new Vector3(transform.position.x, transform.position.y + exYPosition, 0);
            if (ex != null)
                ex.DamageGeneration(damageSpawnPosition, trueDamage);

            hpbar.value = currentHP;
        }
    }
}
