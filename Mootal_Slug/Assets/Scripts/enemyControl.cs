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
        //�Ѿ˰� �÷��̾ ���� ��ġ�������� �浹������ �÷��̾ �з���
        //�Ѿ� ��ġ�� �÷��̾� ���� ��ġ���� �� �� ���� �����ǵ��� ��
        Vector3 pos = this.transform.position;
        pos.x -= 1.8f;
        pos.y += 1.5f;

        GameObject bullet = Instantiate(
            bulletPrefab, pos, Quaternion.identity);
    }
}
