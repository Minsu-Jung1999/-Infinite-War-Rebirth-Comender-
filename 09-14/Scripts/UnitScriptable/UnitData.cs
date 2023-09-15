using System.Collections;
using System.Collections.Generic;
using UnityEditor;
 using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/UnitJob Data", order = int.MaxValue)]
public class UnitData : ScriptableObject
{

    private const string SettingFileDirectory = "Assets/Resources";
    private const string SettingFilePath = "Assets/Resources/ScriptableObjects";



    // ���ݷ�
    [SerializeField] private float unit_attack_amount;
    public float attackAmount { get { return unit_attack_amount; } }
    // ���ݷ� �⺻ ��ȭ
    public void UpgradeAttackAmount(float inc)
    {
        unit_attack_amount += unit_attack_amount * inc;
    }
    // ���ݷ� ��� ��ȭ
    public void InhaceAttackAmount(float inc)
    {
        unit_attack_amount += inc;
    }

    // ���� �ӵ�
    [SerializeField] private float unit_attack_speed;
    public float attackSpeed { get { return unit_attack_speed; } }
    // ���� �ӵ� �⺻ ��ȭ
    public void UpgradeAttackSpeed(float inc)
    {
        unit_attack_speed += unit_attack_speed * inc;
    }
    // ���� �ӵ� ��� ��ȭ
    public void InhaceAttackSpeed(float inc)
    {
        unit_attack_speed += inc;
    }

    // ���� ����
    [SerializeField] private float unit_attack_range;
    public float ar { get { return unit_attack_range; } }

    // ���� �� ���ð� ( ���� ������ )
    [SerializeField] private float unit_attack_delay;
    public float attackDelay { get { return unit_attack_delay; } }

    // ü��
    [SerializeField] private float unit_health;
    public float hp { get { return unit_health; } }
    // ü�� �⺻ ��ȭ
    public void UpgradeHealth(float inc)
    {
        unit_health += unit_health * inc;
    }
    // ü�� ��� ��ȭ
    public void InhaceHealth(float inc)
    {
        unit_health += inc;
    }

    // ����
    [SerializeField] private float unit_defense;
    public float def { get { return unit_defense; } }
    // ���� �⺻ ��ȭ
    public void UpgradeDefense(float inc)
    {
        unit_defense += unit_defense * inc;
    }
    // ���� ��� ��ȭ
    public void InhaceDefense(float inc)
    {
        unit_defense += inc;
    }

    // �̵� �ӵ�
    [SerializeField] private float unit_move_speed;
    public float ms { get { return unit_move_speed; } }

    // ���� ����
    [SerializeField] private int unit_cost;
    public int cost { get { return unit_cost; } }

    // ���� ���� ����
    [SerializeField] private int unit_reward;
    public int reward { get { return unit_reward; } }

    // ��ȭ ���
    [SerializeField] private int unit_upgradeCost;
    public int upgradeCost { get { return unit_upgradeCost; } }
    public void UpgradeInc()
    {
        unit_upgradeCost += (int)(unit_upgradeCost * upgradeMulti);
    }

    // ��ȭ ����
    [SerializeField] private float unit_upgradeMulti;
    public float upgradeMulti { get { return unit_upgradeMulti; } }


    public class OriginalDatas
    {
        private float _ad;
        private float _as;
        private float _ar;
        private float _attackDelay;
        private float _hp;
        private float _def;
        private float _ms;
        private float _cost;
        private float _upCost;
        private float _upMulti;
    }

}
