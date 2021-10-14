using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab1 = null;
    [SerializeField] private GameObject bulletPrefab2 = null;
    [SerializeField] private GameObject people = null;

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
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= 0 && go_left)
        {
            go_left = false;
        }
        if(this.transform.position.x >= 5 && !go_left)
        {
            go_left = true;
        }
        EnemyMove(go_left);

        attackTime += Time.deltaTime;
        if (attackTime > max_attackTime)
        {
            attackTime -= max_attackTime;
            int rand = Random.Range(0, 2);
            if (rand == 1) Attack_up();
            if (rand == 0) Attack_down();
        }

        peopleTime -= Time.deltaTime;
        if(peopleTime < 0)
        {
            people.SetActive(true);
            StartCoroutine(Disabled(people, 1.6f));
            peopleTime += 5.0f;
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
    private void Attack_up()
    {
        isShoot = true;

        if (!isDelay)
        {
            isDelay = true;
            StartCoroutine(makeBullet(bulletPrefab1, 2.0f, 1.6f));
        }
    }

    private void Attack_down()
    {
        isShoot_down = true;
        isShoot_down2 = true;
        if (!isDelay)
        {
            isDelay = true;
            StartCoroutine(makeBullet(bulletPrefab2, 1.5f, 0.6f));
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
}
