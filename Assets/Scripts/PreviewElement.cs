using NaughtyAttributes;
using Nobi.UiRoundedCorners;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewElement : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] ImageWithIndependentRoundedCorners roundedCorners;
    [SerializeField] CanvasGroup canvasGroup;

    [Space, Header("Settings")] 
    [SerializeField] float rotationAmount = 5;
    [SerializeField] float roundingAmount = 70;
    [SerializeField] float animationDuration = 0.3f;
    [SerializeField] float fullScreenAnimationDuration = 1;
    [SerializeField] LeanTweenType easeTypeOut;

    [Space, Header("Content")]
    [SerializeField] PreviewElementPage defaultpreviewPage;
    [SerializeField] PreviewElementPage[] previewPages;
    [SerializeField] MainContentPage fullScreenContentPage;

    int activePageIndex = 0;
    Vector3 initialRotation;

    private void Awake()
    {
        MenuButton.OnButtonEnter += ShakeToFocus;
        MenuButton.OnButtonExit += LoseFocus;
        MenuButton.OnButtonClick += OnMenuOptionClicked;
        initialRotation = gameObject.transform.rotation.eulerAngles;
        //Init pages
        defaultpreviewPage.Index = -1;
        for (int i = 0; i < previewPages.Length; i++)
        {
            previewPages[i].Index = i;
        }
    }

    void ShakeToFocus(MenuButton hoveredButton)
    {
        LeanTween.rotate(gameObject, gameObject.transform.rotation.eulerAngles + new Vector3(0, 0, rotationAmount), animationDuration).setEase(animationCurve);
        LeanTween.value(gameObject, roundingAmount, 0f, animationDuration).setOnUpdate(SetCornersXZ);
        LeanTween.value(gameObject, roundedCorners.r.y, roundingAmount, animationDuration).setOnUpdate(SetCornersYW);

        activePageIndex = hoveredButton.GetAssociatedPage().Index;

        ChangePage();
    }

    void LoseFocus(MenuButton hoveredButton)
    {
        LeanTween.rotate(gameObject, initialRotation, animationDuration).setEase(easeTypeOut);
        LeanTween.value(gameObject, roundedCorners.r.x, roundingAmount, animationDuration).setOnUpdate(SetCornersXZ);
        LeanTween.value(gameObject, roundingAmount, 0, animationDuration).setOnUpdate(SetCornersYW);

        activePageIndex = -1;

        ChangePage();
    }

    void SetCornersXZ(float value)
    {
        roundedCorners.r.x = value;
        roundedCorners.r.z = value;
        roundedCorners.Refresh();
    }

    void SetCornersYW(float value)
    {
        roundedCorners.r.y = value;
        roundedCorners.r.w = value;
        roundedCorners.Refresh();
    }

    void ChangePage()
    {
        //Default Page Preview Content
        defaultpreviewPage.Visible = activePageIndex == -1;

        //Show Page Preview Content
        for (int i = 0; i < previewPages.Length; i++)
        {
            previewPages[i].Visible = i == activePageIndex;
        }
    }

    void OnMenuOptionClicked(MenuButton clickedOption)
    {
        LeanTween.value(gameObject, 0, 1, fullScreenAnimationDuration).setOnUpdate(TweenPreviewSize)
            .setOnComplete(ShowFullScreenPage);
    }

    private void TweenPreviewSize(float lerp)
    {
        RectTransform rectTransform = transform as RectTransform;
        RectTransform fullScreenPageTransfrom = fullScreenContentPage.transform as RectTransform;

        rectTransform.anchorMin = Vector2.Lerp(rectTransform.anchorMin, fullScreenPageTransfrom.anchorMin, lerp);
        rectTransform.anchorMax = Vector2.Lerp(rectTransform.anchorMax, fullScreenPageTransfrom.anchorMax, lerp);
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, fullScreenPageTransfrom.anchoredPosition, lerp);
        rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, fullScreenPageTransfrom.sizeDelta, lerp);
    }

    private void ShowFullScreenPage()
    {
        fullScreenContentPage.gameObject.SetActive(true);
        fullScreenContentPage.Show3DScene();
    }

    private void OnDestroy()
    {
        MenuButton.OnButtonEnter -= ShakeToFocus;
    }
}
