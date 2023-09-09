using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/UnitJob Data", order = int.MaxValue)]
public class UnitData : ScriptableObject
{
    // ���ݷ�
    [SerializeField] private float unit_attack_amount;
    public float attackAmount { get { return unit_attack_amount; } }

    // ���� �ӵ�
    [SerializeField] private float unit_attack_speed;
    public float attackSpeed { get { return unit_attack_speed; } }

    // ���� ����
    [SerializeField] private float unit_attack_range;
    public float ar { get { return unit_attack_range; } }

    // ���� �� ���ð� ( ���� ������ )
    [SerializeField] private float unit_attack_delay;
    public float attackDelay { get { return unit_attack_delay; } }

    // ü��
    [SerializeField] private float unit_health;
    public float hp { get { return unit_health; } }

    // ����
    [SerializeField] private float unit_defense;
    public float def { get { return unit_defense; } }

    // �̵� �ӵ�
    [SerializeField] private float unit_move_speed;
    public float ms { get { return unit_move_speed; } }

    // ���� ����
    [SerializeField] private float unit_cost;
    public float cost { get { return unit_cost; } }

}
