using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] PreviewElement previewElement;
    [SerializeField] Button button;
    [SerializeField] CanvasGroup canvasGroup;
    private static Action OnBackClicked;
    public static BackButton instance => (BackButton) FindObjectOfType(typeof(BackButton));

    private void Awake()
    {
        button.transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0;
        button.onClick.AddListener(() =>
        {
            OnBackClicked.Invoke();
        });
        AnimateIn();
    }

    public static void ReplaceListener(Action newAction)
    {
        OnBackClicked = null;
        OnBackClicked = newAction;
    }

    private void AnimateIn()
    {
        LeanTween.scale(gameObject, Vector3.one, 0.3f);
        LeanTween.alphaCanvas(canvasGroup, 1, 0.3f);
    }

    public void AnimateOut()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.3f).setEaseOutCubic();
        LeanTween.alphaCanvas(canvasGroup, 0, 0.3f).setEaseOutCubic();
    }

    public static void SetInteractable(bool interactable)
    {
        instance.canvasGroup.interactable = interactable;
    }

    private void OnDisable()
    {
        button.transform.localScale = Vector3.zero;
        canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        AnimateIn();
    }
}
