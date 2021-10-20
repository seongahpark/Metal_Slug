using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public GameManager gm;

    [SerializeField] private GameObject bulletPrefab1 = null;
    [SerializeField] private GameObject bulletPrefab2 = null;
    [SerializeField] private GameObject people = null;
    [SerializeField] private GameObject explosionPrefab = null;
    [SerializeField] private GameObject explosionBigPrefab = null;
 
    private bool go_left = true;
    float attackTime = 0;
    float max_attackTime = 3.0f;
    float peopleTime = 5.0f;
    public bool isPeople = false;
    public bool isShoot = false;
    public bool isShoot_down = false;
    public bool isShoot_down2 = false;
    private float delayTime = 1.0f;
    private bool isDelay = false;
    public bool isclear = false;
    public bool e_isAttack = false;
    public float blinkTime = 1.5f;

    public static float maxEnemyHP = 100;
    [SerializeField] private float enemyHP = maxEnemyHP;
    private float enemyHP_10per = maxEnemyHP * 0.1f;

    public bool isfired = false;
    private bool isStop = false; // 정지상태
    private float moveTime = 5.0f;

    private bool deadMotion = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.chkBossStage && !gm.gameClear)
        {
            MoveTime(); // 보스 움직임 / 멈춤 제어
            MoveState(); // 왼쪽, 오른쪽 방향 전환
            if (!isStop) EnemyMove(go_left);

            Attack(); // 보스 공격

            peopleTime -= Time.deltaTime;
            if (peopleTime < 0)
            {
                people.SetActive(true);
                StartCoroutine(Disabled(people, 1.6f));
                peopleTime += 5.0f;
            }

            if (enemyHP <= 0)
            {
                gm.gameClear = true;
                isclear = true;
                if (!deadMotion) enemyDeadMotion();
                Destroy(gameObject, 2.0f);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "P_Bullet" && enemyHP > 0 && gm.chkBossStage)
        {
            e_isAttack = true;
            enemyIsAttackted();
        }
    }

    private void MoveTime()
    {
        moveTime -= Time.deltaTime;
        if (moveTime <= 0)
        {
            moveTime = Random.Range(2.0f, 5.0f);
            isStop = !isStop;
        }
    }

    private void MoveState()
    {
        if (this.transform.position.x <= 23 && go_left)
        {
            go_left = false;
        }
        if (this.transform.position.x >= 26 && !go_left)
        {
            go_left = true;
        }
    }
    private void EnemyMove(bool go_left)
    {
        if (go_left)
        {
            this.transform.position += Vector3.left * Time.deltaTime;
        }

        if (!go_left)
        {
            this.transform.position += Vector3.right * Time.deltaTime;
        }
    }

    private void Attack()
    {
        attackTime += Time.deltaTime;
        if (attackTime > max_attackTime)
        {
            attackTime -= max_attackTime;
            int rand = Random.Range(0, 2);
            if (rand == 1) Attack_up();
            if (rand == 0) Attack_down();
        }
    }
    private void Attack_up()
    {
        isShoot = true;

        if (!isDelay)
        {
            isDelay = true;
            StartCoroutine(makeBullet(bulletPrefab1, 1.5f, 1.0f));
        }
    }

    private void Attack_down()
    {
        isShoot_down = true;
        isShoot_down2 = true;
        if (!isDelay)
        {
            isDelay = true;
            StartCoroutine(makeBullet(bulletPrefab2, 1.0f, 0.5f));
        }
    }

    IEnumerator makeBullet(GameObject bulletPrefab, float _x, float _y)
    {
        yield return new WaitForSeconds(delayTime);

        Vector3 pos = this.transform.position;
        pos.x -= _x;
        pos.y += _y;
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        isDelay = false;
    }

    IEnumerator Disabled(GameObject obj, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        obj.SetActive(false);
    }

    public void enemyIsAttackted()
    {
        enemyHP--;
        if (enemyHP <= enemyHP_10per) isfired = true;
    }

    private void enemyDeadMotion()
    {
        for (int i=0; i<10; i++)
        {
            StartCoroutine(enemyExplosion());
        }
        Vector3 pos = this.transform.position;
        pos.y += 1.0f;
        pos.z = -2;
        Instantiate(explosionBigPrefab, pos, Quaternion.identity);
        
        deadMotion = true;
    }

    IEnumerator enemyExplosion()
    {
        Vector3 pos = this.transform.position;
        pos.x += Random.Range(-2.5f, 2.5f);
        pos.y += Random.Range(-1.0f, 1.0f);
        pos.z = -2;
        Instantiate(explosionPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(blinkTime);
    }

    public IEnumerator Blink(SpriteRenderer sr)
    {
        sr.color = new Color(1, 0.5f, 0.5f, 1);
        yield return new WaitForSeconds(blinkTime);
        sr.color = new Color(1, 1, 1, 1);
        e_isAttack = false;
    }
}
