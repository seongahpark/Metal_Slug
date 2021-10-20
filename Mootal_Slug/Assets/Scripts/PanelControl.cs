using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    public Image image;
    private float fadeCount = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        fadeCount = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        while (fadeCount > 0)
        {
            yield return new WaitForSeconds(0.3f);
            fadeCount -= 0.01f;
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }
}
