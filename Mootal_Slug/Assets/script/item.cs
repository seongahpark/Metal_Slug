using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    Rigidbody2D myrigid;
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
        Invoke("Destroyitem", 10f);
        Invoke("Blink", 7.5f);
    }

    // Update is called once per frame
    void Update()
    {


           
    }
    void Destroyitem()
    {
        
        Destroy(gameObject);
    }
    void Blink()
    {
        StartCoroutine("blink");
    }
    public IEnumerator blink()
    {

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 30; i++)
        {


            sr.enabled = !sr.enabled;

            yield return new WaitForSeconds(0.1f);

        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(myrigid);
        }
    }
}
