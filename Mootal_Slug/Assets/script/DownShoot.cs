using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownShoot : MonoBehaviour
{
    //���� ���¿��� �߻�



    public GameObject bullet;
    public Transform pos;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            DownPlayer.anim.SetBool("Shoot", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            DownPlayer.anim.SetBool("Shoot", false);
        }

    }
    public void shoot()
    {
        Instantiate(bullet, pos.position, transform.rotation);
    }
}
