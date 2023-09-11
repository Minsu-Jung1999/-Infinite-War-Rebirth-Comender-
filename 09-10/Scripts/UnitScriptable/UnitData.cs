using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/UnitJob Data", order = int.MaxValue)]
public class UnitData : ScriptableObject
{
    // 공격력
    [SerializeField] private float unit_attack_amount;
    public float attackAmount { get { return unit_attack_amount; } }

    // 공격 속도
    [SerializeField] private float unit_attack_speed;
    public float attackSpeed { get { return unit_attack_speed; } }

    // 공격 범위
    [SerializeField] private float unit_attack_range;
    public float ar { get { return unit_attack_range; } }

    // 공격 후 대기시간 ( 공격 딜레이 )
    [SerializeField] private float unit_attack_delay;
    public float attackDelay { get { return unit_attack_delay; } }

    // 체력
    [SerializeField] private float unit_health;
    public float hp { get { return unit_health; } }

    // 방어력
    [SerializeField] private float unit_defense;
    public float def { get { return unit_defense; } }

    // 이동 속도
    [SerializeField] private float unit_move_speed;
    public float ms { get { return unit_move_speed; } }

    // 모집 가격
    [SerializeField] private float unit_cost;
    public float cost { get { return unit_cost; } }

}
