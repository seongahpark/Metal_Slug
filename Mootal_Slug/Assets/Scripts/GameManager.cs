using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gm = null;
    public bool chkBossStage = false;
    public bool gameStart = false;
    public bool gameOver = false;
    private bool gameOverScreen = false;
    //player x 좌표가 20이상일때부터 BOSS 모드 ON
    private void Awake()
    {
        if (gm == null) gm = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gm);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !gameOverScreen)
        {
            gameOverScreen = true;
            SceneManager.LoadScene(2);
        }
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            ReStart();
        }
    }

    static public GameManager getIns
    {
        get { return gm; }
    }

    private void ReStart()
    {
        SceneManager.LoadScene(0);
        gameOver = false;
        gameOverScreen = false;
    }
}
