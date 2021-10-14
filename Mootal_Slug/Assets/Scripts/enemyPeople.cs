using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPeople : MonoBehaviour
{
    [SerializeField] private enemyControl ec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(ec.isPeople) this.gameObject.SetActive(true);
        //if(!ec.isPeople) this.gameObject.SetActive(false);
    }
}
