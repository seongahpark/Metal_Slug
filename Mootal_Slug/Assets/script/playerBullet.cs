using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBullet : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] private GameObject isAttacktedPrefab = null;
    [SerializeField] private GameObject isAttacktedMiniPrefab = null;
    float speed = 15.0f;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("DestroyBullet", 2f);
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
        transform.position = transform.position + (transform.right * speed * Time.deltaTime);
    }
    void bulletupmove()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" && gm.chkBossStage && gm.canBossAttack)
        {
            Vector3 pos = this.transform.position;
            pos.y += 1.5f;
            pos.z = -2.0f;
            Instantiate(isAttacktedPrefab, pos, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Enemy" && !gm.chkBossStage && !gm.canBossAttack)
        {
            Destroy(gameObject);
        }

        if (collision.transform.tag == "M_Enemy")
        {
            Instantiate(isAttacktedMiniPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "bullet_border")
        {
            Destroy(gameObject);
        }
    }
}
