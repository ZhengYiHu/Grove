using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentPage : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float appearAnimationDuration = 0.3f;
    [SerializeField] LeanTweenType appearAnimationEase;

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0;
        LeanTween.scale(gameObject, Vector3.one, appearAnimationDuration).setEase(appearAnimationEase);
        LeanTween.alphaCanvas(canvasGroup, 1, appearAnimationDuration).setEase(appearAnimationEase);
    }
}
