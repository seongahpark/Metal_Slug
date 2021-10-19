using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUpBullet : MonoBehaviour
{
    //위로 움직이는 총알


    float speed = 15.0f;
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    
    void Update()
    {


        bulletupmove();

    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
    void bulletupmove()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
    
   
}
