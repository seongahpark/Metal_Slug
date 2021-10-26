using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraEnemyControl : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab = null;
    [SerializeField] public enemyControl ec;
    private Collider2D collison;
    private Animator animator;
    private SpriteRenderer rend;
    private bool isMove = false;
    [SerializeField] private int miniEnemyHp = 10;
    [SerializeField] private int state = 0;
    [SerializeField] private float stateTime = 1.5f;

    private bool dropChk = false;
    //state 0 : 정지, 1 : 걷기, 2 : 하울링, 3 : destroyed

    // Start is called before the first frame update
    void Start()
    {
        ec = GameObject.Find("Enemy").GetComponent<enemyControl>();
        rend = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collison = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        stateTime -= Time.deltaTime;
        if (stateTime <= 0) changeState();
        chkState();

        if (miniEnemyHp <= 0)
        {
            if (!dropChk) DropItem(); // 일정 확률로 아이템 드롭
            collison.isTrigger = true;
            animator.SetBool("isDestroyed", true);
            Destroy(this.gameObject, 1.0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "P_Bullet")
        {
            StartCoroutine(ec.Blink(rend));
            miniEnemyHp--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "P_Bomb")
        {
            StartCoroutine(ec.Blink(rend));
            miniEnemyHp -= 3;
        }
    }
    private void changeState()
    {
        state = Random.Range(0, 3);
        switch (state)
        {
            case 0:
                stateTime += 1.0f;
                break;
            case 1:
                stateTime += 3.0f;
                break;
            case 2:
                stateTime += 2.0f;
                break;
        }
    }
    private void chkState()
    {
        if (state == 0)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isHowling", false);
            isMove = false;
        }
        if (state == 1)
        {
            animator.SetBool("isHowling", false);
            animator.SetBool("isMoving", true);
            if(!isMove) StartCoroutine(WaitForMove());
            if (isMove) Moving();
            isMove = true;
        }
        if (state == 2)
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isHowling", true);
            isMove = false;
        }
    }
    private void Moving()
    {
        this.transform.position += Vector3.left * Time.deltaTime * 0.5f;
    }

    IEnumerator WaitForMove()
    {
        yield return new WaitForSeconds(0.5f);
        Moving();
    }

    private void DropItem()
    {
        dropChk = true;
        int rand = Random.Range(0, 100);
        if (rand <= 30)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
