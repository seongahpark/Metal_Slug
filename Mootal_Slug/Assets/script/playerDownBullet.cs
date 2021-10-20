using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDownBullet : MonoBehaviour
{
    //�Ʒ��� �����̴� �Ѿ�
    public GameManager gm;
    [SerializeField] private GameObject isAttacktedPrefab = null;
    [SerializeField] private GameObject isAttacktedMiniPrefab = null;



    float speed = 15.0f;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("DestroyBullet", 0.3f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" && gm.chkBossStage)
        {
            Vector3 pos = this.transform.position;
            pos.y += 1.5f;
            pos.z = -2.0f;
            Instantiate(isAttacktedPrefab, pos, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.transform.tag == "Enemy" && !gm.chkBossStage)
        {
            Destroy(gameObject);
        }
        if (collision.transform.tag == "M_Enemy")
        {
            Instantiate(isAttacktedMiniPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
