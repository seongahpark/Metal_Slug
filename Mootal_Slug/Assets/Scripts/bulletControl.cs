using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{
    private float speed = 3f;
    private float lifeTime = 3f;
    bool isShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        //총알 기본 회전값 설정
        Vector3 pos = this.transform.position;
        pos.z = -1;
        this.transform.position = pos;
        this.transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        if (!isShoot) return;
        transform.position += (Vector3.left * speed * Time.deltaTime);
    }
    public void Shoot()
    {
        isShoot = true;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy") Destroy(gameObject);
    }
}
