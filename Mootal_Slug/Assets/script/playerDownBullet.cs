using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDownBullet : MonoBehaviour
{
    //�Ʒ��� �����̴� �Ѿ�




    float speed = 15.0f;
    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
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
        transform.Translate(transform.up*-1 * speed * Time.deltaTime);
    }

}
