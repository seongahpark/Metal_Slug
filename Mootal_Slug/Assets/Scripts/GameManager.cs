using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager gm = null;
    public bool chkBossStage = false;
    //player x ��ǥ�� 20�̻��϶����� BOSS ��� ON
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
