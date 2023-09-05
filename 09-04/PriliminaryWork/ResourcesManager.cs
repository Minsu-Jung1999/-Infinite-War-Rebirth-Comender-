using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance;

    public int money;

    // insatnce�� �ڱ� �ڽ����� �ʱ�ȭ �ϰ�, ���� �Ѿ �� �ߺ������� �� �ش�.
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
