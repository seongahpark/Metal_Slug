using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gm = null;
    public bool chkBossStage = false;
    //player x 좌표가 20이상일때부터 BOSS 모드 ON
    private void Awake()
    {
        if (gm == null) gm = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public GameManager getIns
    {
        get { return gm; }
    }
}
