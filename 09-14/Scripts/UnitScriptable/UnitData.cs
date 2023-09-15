using System.Collections;
using System.Collections.Generic;
using UnityEditor;
 using UnityEngine;

[CreateAssetMenu(fileName = "Unit Data", menuName = "Scriptable Object/UnitJob Data", order = int.MaxValue)]
public class UnitData : ScriptableObject
{

    private const string SettingFileDirectory = "Assets/Resources";
    private const string SettingFilePath = "Assets/Resources/ScriptableObjects";



    // 공격력
    [SerializeField] private float unit_attack_amount;
    public float attackAmount { get { return unit_attack_amount; } }
    // 공격력 기본 강화
    public void UpgradeAttackAmount(float inc)
    {
        unit_attack_amount += unit_attack_amount * inc;
    }
    // 공격력 상급 강화
    public void InhaceAttackAmount(float inc)
    {
        unit_attack_amount += inc;
    }

    // 공격 속도
    [SerializeField] private float unit_attack_speed;
    public float attackSpeed { get { return unit_attack_speed; } }
    // 공격 속도 기본 강화
    public void UpgradeAttackSpeed(float inc)
    {
        unit_attack_speed += unit_attack_speed * inc;
    }
    // 공격 속도 상급 강화
    public void InhaceAttackSpeed(float inc)
    {
        unit_attack_speed += inc;
    }

    // 공격 범위
    [SerializeField] private float unit_attack_range;
    public float ar { get { return unit_attack_range; } }

    // 공격 후 대기시간 ( 공격 딜레이 )
    [SerializeField] private float unit_attack_delay;
    public float attackDelay { get { return unit_attack_delay; } }

    // 체력
    [SerializeField] private float unit_health;
    public float hp { get { return unit_health; } }
    // 체력 기본 강화
    public void UpgradeHealth(float inc)
    {
        unit_health += unit_health * inc;
    }
    // 체력 상급 강화
    public void InhaceHealth(float inc)
    {
        unit_health += inc;
    }

    // 방어력
    [SerializeField] private float unit_defense;
    public float def { get { return unit_defense; } }
    // 방어력 기본 강화
    public void UpgradeDefense(float inc)
    {
        unit_defense += unit_defense * inc;
    }
    // 방어력 상급 강화
    public void InhaceDefense(float inc)
    {
        unit_defense += inc;
    }

    // 이동 속도
    [SerializeField] private float unit_move_speed;
    public float ms { get { return unit_move_speed; } }

    // 모집 가격
    [SerializeField] private int unit_cost;
    public int cost { get { return unit_cost; } }

    // 코인 보상 가격
    [SerializeField] private int unit_reward;
    public int reward { get { return unit_reward; } }

    // 강화 비용
    [SerializeField] private int unit_upgradeCost;
    public int upgradeCost { get { return unit_upgradeCost; } }
    public void UpgradeInc()
    {
        unit_upgradeCost += (int)(unit_upgradeCost * upgradeMulti);
    }

    // 강화 배율
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
