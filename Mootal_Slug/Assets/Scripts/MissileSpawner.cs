using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameManager gm;

    [SerializeField] private GameObject missilePrefab = null;
    private float spawnerTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.chkBossStage)
        {
            Spawner();
        }
    }

    private void Spawner()
    {
        spawnerTime -= Time.deltaTime;
        if (spawnerTime < 0)
        {
            Vector3 pos = this.transform.position;
            pos.x += Random.Range(-3.7f, 3.0f);
            pos.z = -1.0f;
            spawnerTime = 1.5f;
            Instantiate(missilePrefab, pos, Quaternion.identity);
        }
    }
}
