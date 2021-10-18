using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFired : MonoBehaviour
{
    private static int arrSize = 5;
    [SerializeField] private enemyControl ec;
    [SerializeField] private GameObject[] fireObject = new GameObject[arrSize];
    // Start is called before the first frame update

    void Start()
    {
        for (int i = 0; i < arrSize; i++)
        {
            fireObject[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ec.isfired)
        {
            for(int i=0; i<arrSize; i++)
            {
                fireObject[i].SetActive(true);
            }
        }

        if (ec.isclear)
        {
            for (int i = 0; i < arrSize; i++)
            {
                fireObject[i].SetActive(false);
            }
        }
    }
}
