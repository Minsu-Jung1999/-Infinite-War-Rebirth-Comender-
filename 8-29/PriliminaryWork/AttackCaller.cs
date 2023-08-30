using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCaller : MonoBehaviour
{
    [SerializeField] ShootingArrow shot;

    public void Attack()
    {
        shot.Fire();
    }
}
