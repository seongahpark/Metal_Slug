using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour
{
    [SerializeField] private GameObject flashPrefab = null;
    private float speed = 2.0f;
    private float destroyTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        this.transform.position += Vector3.down * Time.deltaTime * speed;
        if (destroyTime <= 0)
        {
            Vector3 pos = this.transform.position;
            pos.y -= 0.3f;
            Instantiate(flashPrefab, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
