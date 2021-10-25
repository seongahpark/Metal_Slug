using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bomb : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab = null;
    Rigidbody2D myrigidbody;

    public float bombSpeed;

    int count = 3;


    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myrigidbody.velocity = transform.right * bombSpeed;
        myrigidbody.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (count < 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        count--;
        if (collision.gameObject.tag == "M_Enemy")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
