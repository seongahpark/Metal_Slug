using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bomb_txt : MonoBehaviour
{
    Text tx;

    void Start()
    {
        tx = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        tx.text = playershoot.bombcount.ToString("D3");
    }
}
