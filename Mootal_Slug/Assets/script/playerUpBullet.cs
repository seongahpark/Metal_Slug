using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUpBullet : MonoBehaviour
{
    //위로 움직이는 총알

    [SerializeField] private GameObject isAttacktedPrefab = null;
    [SerializeField] private GameObject isAttacktedMiniPrefab = null;
    float speed = 15.0f;
    void Start()
    {
        Invoke("DestroyBullet", 0.3f);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Instantiate(isAttacktedPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "M_Enemy")
        {
            Instantiate(isAttacktedMiniPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
