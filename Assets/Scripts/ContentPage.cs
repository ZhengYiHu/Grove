using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentPage : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float appearAnimationDuration = 0.3f;
    [SerializeField] LeanTweenType appearAnimationEase;
    [SerializeField] Image bg;

    public Color bgColor => bg.color;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0;
        LeanTween.scale(gameObject, Vector3.one, appearAnimationDuration).setEase(appearAnimationEase);
        LeanTween.alphaCanvas(canvasGroup, 1, appearAnimationDuration).setEase(appearAnimationEase);
    }
}
