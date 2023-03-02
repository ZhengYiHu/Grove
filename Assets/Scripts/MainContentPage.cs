using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContentPage : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;

    public void ShowPageWithAnimation()
    {
        canvasGroup.alpha = 0;
        LeanTween.alphaCanvas(canvasGroup, 1, 0.3f);
    }

    public void Show3DScene()
    {

    }
}
