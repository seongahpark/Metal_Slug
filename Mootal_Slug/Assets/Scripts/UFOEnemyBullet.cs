using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemyBullet : MonoBehaviour
{
    private float speed = 1.5f;
    private float lifetime = 2.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * speed * Time.deltaTime);
        transform.position += (Vector3.down * speed * Time.deltaTime);
        Destroy(gameObject, lifetime);
    }
}
