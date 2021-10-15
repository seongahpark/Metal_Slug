using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTop : MonoBehaviour
{
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
        if (ec.isShoot)
        {
            animator.SetTrigger("isShoot");
            ec.isShoot = false;
        }

        if (ec.isclear)
        {
            this.gameObject.SetActive(false);
        }

        if (ec.e_isAttack)
        {
            StartCoroutine(ec.Blink(rend));
        }
    }

}
