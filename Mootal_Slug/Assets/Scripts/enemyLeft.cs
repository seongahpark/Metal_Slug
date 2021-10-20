using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLeft : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] private enemyControl ec;
    Animator animator;
    SpriteRenderer rend;

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
                if (ec.isShoot_down2)
                {
                    animator.SetTrigger("isShoot");
                    ec.isShoot_down2 = false;
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
