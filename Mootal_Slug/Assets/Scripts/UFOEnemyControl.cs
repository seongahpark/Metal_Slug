using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemyControl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] public enemyControl ec;
    private Animator animator;
    private SpriteRenderer rend;

    [SerializeField] private int miniEnemyHp = 10;
    private static float attackMaxTime = 3.0f;
    private float attackTime = attackMaxTime;
    [SerializeField] private static float posMaxTime = 1.5f;
    [SerializeField] private float posTime = posMaxTime / 2.0f;
    private int pos = 1;
    // Start is called before the first frame update
    void Start()
    {
        ec = GameObject.Find("Enemy").GetComponent<enemyControl>();
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        attackTime -= Time.deltaTime;
        if(attackTime <= 0)
        {
            attackTime = attackMaxTime;
            Attack();
        }

        if (miniEnemyHp <= 0)
        {
            animator.SetBool("isDestroyed", true);
            Destroy(this.gameObject, 2.0f);
        }
        else Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "P_Bullet")
        {
            StartCoroutine(ec.Blink(rend));
            miniEnemyHp--;
        }
    }

    private void Move()
    {
        posTime -= Time.deltaTime;
        if (posTime > 0) pos = -1;
        if (posTime < 0) pos = 1;
        if (posTime < -posMaxTime) posTime += posMaxTime*2;
        transform.Translate(Vector3.down * Time.deltaTime * pos * 0.5f);
    }
    private void Attack()
    {
        Vector3 pos = transform.position;
        pos.y -= 0.3f;
        pos.z = -1.0f;
        Instantiate(bulletPrefab, pos, Quaternion.identity);
    }
}
