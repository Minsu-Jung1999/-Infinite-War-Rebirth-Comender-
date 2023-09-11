using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitStatInfoManager : MonoBehaviour
{

    [SerializeField] GameObject unit;
        
    [SerializeField] TMP_Text healthPoint;
    [SerializeField] TMP_Text attackDamage;
    [SerializeField] TMP_Text attackSpeed;
    [SerializeField] TMP_Text armo;
    [SerializeField] TMP_Text moveSpeed;

    UnitCombat unitcom;

    public bool isUpdating;

    private void Start()
    {
        unitcom = unit.GetComponent<UnitCombat>();
        isUpdating = true;
    }

    private void Update()
    {
        if(isUpdating)
        {
            healthPoint.text = unitcom.GetCurrentHP().ToString();
            attackDamage.text = unitcom.GetCurrentAD().ToString();
            attackSpeed.text = unitcom.GetCurrentAS().ToString();
            armo.text = unitcom.GetCurrentAR().ToString();
            moveSpeed.text = unitcom.GetCurrentMS().ToString();
            isUpdating = false;
        }
    }

}
