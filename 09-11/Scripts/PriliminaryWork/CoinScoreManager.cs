using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinScoreManager : MonoBehaviour
{

    private TMP_Text money_txt;

    // Start is called before the first frame update
    void Start()
    {
        money_txt = GetComponent<TMP_Text>();            
    }

    // Update is called once per frame
    void Update()
    {
        money_txt.text = ResourcesManager.instance.money.ToString();
    }
}
