using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraEnemyControl : MonoBehaviour
{
    [SerializeField] public enemyControl ec;
    private Animator animator;
    private SpriteRenderer rend;
    private bool isMove = false;
    [SerializeField] private int miniEnemyHp = 10;
    [SerializeField] private int state = 0;
    [SerializeField] private float stateTime = 1.5f;
    //state 0 : ����, 1 : �ȱ�, 2 : �Ͽ︵, 3 : destroyed

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
        stateTime -= Time.deltaTime;
        if (stateTime <= 0) changeState();
        chkState();

        if (miniEnemyHp <= 0)
        {
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
}