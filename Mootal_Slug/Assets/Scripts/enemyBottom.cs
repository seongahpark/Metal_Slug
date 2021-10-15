using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBottom : MonoBehaviour
{
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
        if (ec.isclear)
        {
            animator.SetBool("isDestroyed", true);
        }

        if (ec.e_isAttack)
        {
            StartCoroutine(ec.Blink(rend));
        }
    }
}
