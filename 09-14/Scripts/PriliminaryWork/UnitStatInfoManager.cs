using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitStatInfoManager : MonoBehaviour
{

    [SerializeField] GameObject unit;
        
    [Header("Stat")]
    [SerializeField] TMP_Text healthPoint;
    [SerializeField] TMP_Text attackDamage;
    [SerializeField] TMP_Text attackSpeed;
    [SerializeField] TMP_Text armo;
    [SerializeField] TMP_Text moveSpeed;

    [Header("Cost")]
    [SerializeField] TMP_Text spawn_txt;
    [SerializeField] TMP_Text upgrade_txt;

    UnitCombat unitcom;


    private void Start()
    {
        unitcom = unit.GetComponent<UnitCombat>();
    }

    private void Update()
    {
        SetStatInfo();
        SetSpawnCost();
        SetUpgradeCost();
    }

    private void SetStatInfo()
    {
        healthPoint.text = unitcom.GetCurrentHP().ToString("F0");
        attackDamage.text = unitcom.GetCurrentAD().ToString("F0");
        attackSpeed.text = unitcom.GetCurrentAS().ToString("F1");
        armo.text = unitcom.GetCurrentAR().ToString("F0");
        moveSpeed.text = unitcom.GetCurrentMS().ToString("F1");
    }

    private void SetSpawnCost()
    {
        spawn_txt.text = unitcom.GetCurrentCost().ToString();
    }

    private void SetUpgradeCost()
    {
        upgrade_txt.text = unitcom.GetCurrentUpgradeCost().ToString();
    }

    public void UpgradeButton()
    {
        if(ResourcesManager.instance.money >= unitcom.GetCurrentUpgradeCost())
        {
            ResourcesManager.instance.MoneyDecreasing(unitcom.GetCurrentUpgradeCost());
            
            unitcom.HPIncreasing(0.02f);
            unitcom.ARIncreasing(0.02f);
            unitcom.ASIncreasing(0.01f);
            unitcom.ADIncreasing(0.02f);

            unitcom.UpgradeCostincreasing();

        }
    }
}
