using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBottom : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] enemyControl ec;
    private Animator animator;
    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.chkBossStage)
        {
            if (!ec.isclear)
            {
                if (ec.e_isAttack)
                {
                    StartCoroutine(ec.Blink(rend));
                }
            }
            if (ec.isclear)
            {
                animator.SetBool("isDestroyed", true);
            }
        }
    }
}
