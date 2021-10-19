using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab = null;
    private float spawnerTime = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnerTime -= Time.deltaTime;
        if(spawnerTime < 0)
        {
            Vector3 pos = this.transform.position;
            pos.x += Random.Range(-3.0f, 3.0f);
            pos.z = -1.0f;
            spawnerTime = 2.0f;
            Instantiate(missilePrefab, pos, Quaternion.identity);
        }
    }
}
