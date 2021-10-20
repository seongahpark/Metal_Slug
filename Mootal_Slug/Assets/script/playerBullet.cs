using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    [SerializeField] private GameObject isAttacktedPrefab = null;
    [SerializeField] private GameObject isAttacktedMiniPrefab = null;
    float speed = 15.0f;
    void Start()
    {
        Invoke("DestroyBullet", 0.3f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Vector3 pos = this.transform.position;
            pos.y += 1.5f;
            pos.z = -2.0f;
            Instantiate(isAttacktedPrefab, pos, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "M_Enemy")
        {
            Instantiate(isAttacktedMiniPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
