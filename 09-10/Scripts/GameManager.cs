using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isCenter;

    // insatnce�� �ڱ� �ڽ����� �ʱ�ȭ �ϰ�, ���� �Ѿ �� �ߺ������� �� �ش�.
    private void Awake()
    {
        if (instance == null)
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
