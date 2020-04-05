using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public static UIFader instance;

    private void Awake()
    {
        instance = this;
    }

    public void FadeUIGroup(CanvasGroup canvasGroup, float waitTime, float fadeSpeed) => StartCoroutine(FadeOut(canvasGroup, waitTime, fadeSpeed));
    

    IEnumerator FadeOut(CanvasGroup canvasGroup, float waitTime, float fadeSpeed)
    {
        yield return new WaitForSeconds(waitTime);
        while(canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 1.5f;
            yield return new WaitForSeconds(fadeSpeed);
        }
        canvasGroup.gameObject.SetActive(false);
    }

}
