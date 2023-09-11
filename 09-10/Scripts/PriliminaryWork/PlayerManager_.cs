using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_ : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isCenter)
        {
            anim.SetBool("Run",true);
        }
        else
        {
            anim.SetBool("Run",false);
        }
    }
}
