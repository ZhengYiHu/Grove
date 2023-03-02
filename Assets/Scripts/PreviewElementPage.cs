using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewElementPage : MonoBehaviour
{
    [SerializeField] float animationDuration = 0.3f;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] LeanTweenType previewEaseType;
    public int Index;
    private bool _visible = false;
    public bool Visible
    {
        set
        {
            _visible = value;
            if(_visible)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
        get
        {
            return _visible;
        }
    }

    private void Show()
    {
        LeanTween.scale(gameObject, Vector2.one, animationDuration).setEase(previewEaseType);
        LeanTween.alphaCanvas(canvasGroup, 1, animationDuration).setEase(previewEaseType);
    }

    private void Hide()
    {
        LeanTween.scale(gameObject, Vector2.zero, animationDuration).setEase(previewEaseType);
        LeanTween.alphaCanvas(canvasGroup, 0, animationDuration).setEase(previewEaseType);
    }
}
