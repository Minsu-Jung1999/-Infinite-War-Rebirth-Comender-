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
        StatTextInfo();
        SetSpawnCost();
    }

    private void StatTextInfo()
    {
        healthPoint.text = unitcom.GetCurrentHP().ToString();
        attackDamage.text = unitcom.GetCurrentAD().ToString();
        attackSpeed.text = unitcom.GetCurrentAS().ToString();
        armo.text = unitcom.GetCurrentAR().ToString();
        moveSpeed.text = unitcom.GetCurrentMS().ToString();
    }

    private void SetSpawnCost()
    {
        spawn_txt.text = unitcom.GetCurrentCost().ToString();
    }

    private void SetUpgradeCost()
    {

    }
}
