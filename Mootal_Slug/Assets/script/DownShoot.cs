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
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (playershoot.bombcount > 0)
            {
                player_item_Down.anim.SetTrigger("Bomb");
                DownPlayer.anim.SetTrigger("Bomb");
                playershoot.bombcount--;
            }
        }
        //if (Input.GetKeyUp(KeyCode.Z))
        //{
        //    player_item_Down.anim.SetBool("bomb", false);
        //    DownPlayer.anim.SetBool("bomb", false);
        //}

    }
    public void shoot()
    {
        if (PlayerManager.itemcheck == false)
            Instantiate(bullet, pos.position, transform.rotation);
        else 
        {
            Instantiate(bullet, pos.position, transform.rotation);
            PlayerManager.Shot_Count--;
        }
        
    }
    void bombshot()
    {
        Instantiate(bomb, bomppos.position, bomppos.rotation);
    }
}
