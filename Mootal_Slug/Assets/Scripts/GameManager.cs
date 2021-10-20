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
    public bool gameClear = false;
    public bool gameOverScreen = false;
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
        if ((gameClear || gameOver) && !gameOverScreen)
        {
            gameOverScreen = true;
            StartCoroutine(waitForChange()); //3초 뒤 화면전환
        }
        if ((gameClear || gameOver) && Input.GetKeyDown(KeyCode.R))
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
        gameClear = false;
        gameOver = false;
        gameOverScreen = false;
        chkBossStage = false;
}

    IEnumerator waitForChange()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(2);
    }
}
