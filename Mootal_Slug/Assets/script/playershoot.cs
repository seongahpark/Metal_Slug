using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playershoot : MonoBehaviour
{
    public PlayerManager pm;
    [SerializeField] private Text armsText;

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bomb;

    public Transform pos;
    public Transform pos2;
    public Transform pos3;
    public Transform bomppos;

    public static int bombcount; //폭탄갯수
    public static bool shootcheck = false;

    void Start()
    {
        bombcount = 10;
        pm.shootCount = 1000;
    }
    void Update()
    {
        shootbutton();
        playerbomb();
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
    private IEnumerator shoo_up1()
    {
        int count = 4;
        float angle = 0f;
        float angleDelta = 90f / count;
        while (count > 0)
        {
            Quaternion newrotation = Quaternion.Euler(pos.rotation.eulerAngles + new Vector3(0f, 0f, angle));
            Instantiate(bullet, pos.position, newrotation);
            //Instantiate(bullet, pos4.position,pos4.rotation=Quaternion.Euler(0f,0f,angle));
            angle += angleDelta;
            count--;
            yield return new WaitForSeconds(0.05f);
            //yield return null;

        }
    }
    private IEnumerator shoot_down1()
    {
        int count = 4;
        float angle = 90f;
        float angleDelta = 90f / count;
        while (count > 0)
        {
            Quaternion newrotation = Quaternion.Euler(pos.rotation.eulerAngles + new Vector3(0f, 0f, angle));
            Instantiate(bullet, pos.position, newrotation);
            //Instantiate(bullet, pos4.position,pos4.rotation=Quaternion.Euler(0f,0f,angle));
            angle -= angleDelta;
            count--;
            yield return new WaitForSeconds(0.05f);
            //yield return null;
        }
    }
    public void shootbutton()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            shootcheck = true;
            if (PlayerManager.itemcheck == false)
                playerbody.anim.SetBool("Shoot", true);
            else if (PlayerManager.itemcheck == true)
            {
                player_item_body.anim.SetBool("Shoot", true);
                pm.shootCount--;
                armsText.text = pm.shootCount.ToString();
                if (pm.shootCount <= 0) itemChk();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            shootcheck = false;
            if (PlayerManager.itemcheck == false)
                playerbody.anim.SetBool("Shoot", false);
            else if (PlayerManager.itemcheck == true)
                player_item_body.anim.SetBool("Shoot", false);
        }
    }
    void playerbomb()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (bombcount > 0)
            {
                playerbody.anim.SetBool("bomb", true);
                player_item_body.anim.SetBool("bomb", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {

            playerbody.anim.SetBool("bomb", false);
            player_item_body.anim.SetBool("bomb", false);
        }
    }
    void bombshot()
    {
        Instantiate(bomb, bomppos.position, bomppos.rotation);
    }

    public void itemChk()
    {
        pm.pickoff_item();
    }
}
