using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnedUnitsIndicator : MonoBehaviour
{
    [SerializeField] Transform objectPoolParent;   

    [SerializeField] TMP_Text SowrdMan;
    [SerializeField] TMP_Text Archer;
    [SerializeField] TMP_Text Magician;
    [SerializeField] TMP_Text Shielder;
    [SerializeField] TMP_Text Skeleton;

    private List<Transform> unitsParent;

    private void Start()
    {
        if (objectPoolParent == null)
        {
            Debug.LogError("Object Pool Parent가 설정되지 않았습니다.");
            return;
        }

        unitsParent = new List<Transform>();

        // Object Pool의 자식들을 unitsParent 리스트에 저장합니다.
        for (int i = 0; i < objectPoolParent.childCount; i++)
        {
            Transform child = objectPoolParent.GetChild(i);
            unitsParent.Add(child);
        }
    }

    private void Update()
    {
        GetActiveSwordManChildCount();
    }

    public void GetActiveSwordManChildCount()
    {
        int species=0;
        foreach (Transform unit in unitsParent)
        {
            int activeChildCount = 0;

            // 현재 자식 오브젝트의 자식 중 SetActive가 true인 오브젝트를 찾아 개수를 세어줍니다.
            for (int i = 0; i < unit.childCount; i++)
            {
                Transform child = unit.GetChild(i);
                if (child.gameObject.activeSelf)
                {
                    activeChildCount++;
                }
            }
            switch (species)
            {
                case 0:
                    SowrdMan.text = activeChildCount.ToString();
                    break;
                case 1:
                    Archer.text = activeChildCount.ToString();
                    break;
                case 2:
                    Magician.text = activeChildCount.ToString();
                    break;
                case 3:
                    Shielder.text = activeChildCount.ToString();
                    break;
                case 4:
                    Skeleton.text = activeChildCount.ToString();
                    break;
                default:
                    break;
            }
            species++;
        }
    }

}
