using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverSceneControl : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameClear)
        {
            image.GetComponent<Image>().sprite = Resources.Load("GameClearScreen", typeof(Sprite)) as Sprite;
            text.GetComponent<Text>().text = "GAME CLEAR";
        }
    }
}
