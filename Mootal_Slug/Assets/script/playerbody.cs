using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbody : MonoBehaviour
{
    


   bool upcheck = false;


    
    public static Animator anim;

    


    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
    void Start()
    {
    }

    
    void Update()
    {
        
        Playerup();
    }
   
    void Playerup()
    {
        if (PlayerManager.jumpCount == 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                upcheck = true;
                anim.SetBool("Up", upcheck);
            }
        }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                upcheck = false;
                anim.SetBool("Up", upcheck);
            }

    }
}
