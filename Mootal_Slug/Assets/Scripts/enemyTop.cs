using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTop : MonoBehaviour
{
    [SerializeField] private enemyControl ec;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ec.isShoot)
        {
            animator.SetTrigger("isShoot");
            ec.isShoot = false;
        }
    }
}
