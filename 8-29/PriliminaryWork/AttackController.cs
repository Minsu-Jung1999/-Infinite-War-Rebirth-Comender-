using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxcoll;

    private void Start()
    {
        boxcoll.enabled = false;
    }

    public void StartAttack()
    {
        boxcoll.enabled = true;
    }

    public void EndAttack()
    {
        boxcoll.enabled = false;
    }


}
