using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    Rigidbody2D myrigid;
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


           
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(myrigid);
        }
    }
}
