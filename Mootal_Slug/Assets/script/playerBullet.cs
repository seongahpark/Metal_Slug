using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{

    float speed = 15.0f;
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

   
    void Update()
    {
        
           
            bulletmove();

    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    void bulletmove()
    {
        if (transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

    }
    void bulletupmove()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
