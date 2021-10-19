using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;

    public Transform pos;
    public Transform pos2;
    public Transform pos3;

    void Start()
    {
        
    }

    
    void Update()
    {
        shootbutton();
    }
    public void shoot()  //평상시
    {
        Instantiate(bullet, pos.position, transform.rotation);
    }
    public void upshoot() //위를 보면서
    {
        Instantiate(bullet2, pos2.position, transform.rotation);
    }
    public void jumpdownshoot() //점프중 아래를 보면서
    {
        Instantiate(bullet3, pos3.position, transform.rotation);
    }
   public void shootbutton()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerbody.anim.SetBool("Shoot", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerbody.anim.SetBool("Shoot", false);
        }
    }
}
