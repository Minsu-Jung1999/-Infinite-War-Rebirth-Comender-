using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager_ : MonoBehaviour
{
    
    private Animator anim;
    // 치졸한 방법인데...
    [SerializeField] private Material render;
    private Vector2 oldPos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        oldPos = render.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldPos.x < render.mainTextureOffset.x)
        {
            anim.SetBool("Run", true);
            oldPos.x = render.mainTextureOffset.x;
        }
        else
        {
            anim.SetBool("Run", false); 
        }
        
    }
}
