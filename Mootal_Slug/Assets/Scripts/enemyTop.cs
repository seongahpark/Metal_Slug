using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTop : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] private enemyControl ec;
    private SpriteRenderer rend;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.chkBossStage)
        {
            if (!gm.gameClear)
            {
                if (ec.isShoot)
                {
                    animator.SetTrigger("isShoot");
                    ec.isShoot = false;
                }

                if (ec.e_isAttack)
                {
                    StartCoroutine(ec.Blink(rend));
                }
            }
            if (gm.gameClear)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}
