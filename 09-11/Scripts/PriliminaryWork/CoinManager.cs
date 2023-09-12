using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField] TMP_Text money_txt;
    [SerializeField] int coinAddAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ResourcesManager.instance.MoneyIncreasing(coinAddAmount);
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        ObjectPolling.ReturnToPool(gameObject);
    }
}
