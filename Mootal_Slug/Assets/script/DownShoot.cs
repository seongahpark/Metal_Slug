using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownShoot : MonoBehaviour
{
    //숙인 상태에서 발사



    public GameObject bullet;
    public GameObject bomb;

    public Transform pos;
    public Transform bomppos;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
           
            DownPlayer.anim.SetBool("Shoot", true);
            player_item_Down.anim.SetBool("Shoot", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            
            DownPlayer.anim.SetBool("Shoot", false);
            player_item_Down.anim.SetBool("Shoot", false);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {


            player_item_Down.anim.SetBool("bomb", true);
            DownPlayer.anim.SetBool("bomb", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            player_item_Down.anim.SetBool("bomb", false);
            DownPlayer.anim.SetBool("bomb", false);
        }

    }
    public void shoot()
    {
        Instantiate(bullet, pos.position, transform.rotation);
    }
    void bombshot()
    {
        Instantiate(bomb, bomppos.position, bomppos.rotation);
    }
}
