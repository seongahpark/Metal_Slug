using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    private bool go_left = true;
    float attackTime = 0;
    float max_attackTime = 1.0f;
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
            Attack();
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
        //총알과 플레이어가 같은 위치에있으면 충돌때문에 플레이어가 밀려남
        //총알 위치를 플레이어 현재 위치보다 좀 더 위에 생성되도록 함
        Vector3 pos = this.transform.position;
        pos.x -= 1.8f;
        pos.y += 1.5f;

        GameObject bullet = Instantiate(
            bulletPrefab, pos, Quaternion.identity);
    }
}
