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
    RectTransform originalTransform;

    private void Awake()
    {
        originalTransform = RectTransformHelper.Clone(transform as RectTransform);
        EnableOnPointerListeners(true);
        MenuButton.OnButtonClick += OnMenuOptionClicked;
        //Restore listeners when back on menu

        initialRotation = gameObject.transform.rotation.eulerAngles;
        //Init pages
        defaultpreviewPage.Index = -1;
        for (int i = 0; i < previewPages.Length; i++)
        {
            previewPages[i].Index = i;
        }
    }

    /// <summary>
    /// Enable or disables listeners for the menu buttons
    /// </summary>
    /// <param name="enable"></param>
    void EnableOnPointerListeners(bool enable)
    {
        if(enable)
        { 
            MenuButton.OnButtonEnter -= ShakeToFocus;
            MenuButton.OnButtonEnter += ShakeToFocus;
            MenuButton.OnButtonExit -= LoseFocus;
            MenuButton.OnButtonExit += LoseFocus;
        }
        else
        {
            MenuButton.OnButtonEnter = null;
            MenuButton.OnButtonExit = null;
        }
    }

    /// <summary>
    /// Perform a Shake animation when a menu button is hovered
    /// </summary>
    /// <param name="hoveredButton"></param>
    void ShakeToFocus(MenuButton hoveredButton)
    {
        LeanTween.rotate(gameObject, gameObject.transform.rotation.eulerAngles + new Vector3(0, 0, rotationAmount), animationDuration).setEase(animationCurve);
        LeanTween.value(gameObject, roundingAmount, 0f, animationDuration).setOnUpdate(SetCornersXZ);
        LeanTween.value(gameObject, roundedCorners.r.y, roundingAmount, animationDuration).setOnUpdate(SetCornersYW);

        activePageIndex = hoveredButton.GetAssociatedPage().Index;
        ChangePage();
    }

    /// <summary>
    /// Restore the initial position when no button is being focused
    /// </summary>
    /// <param name="hoveredButton"></param>
    void LoseFocus(MenuButton hoveredButton)
    {
        SetInitialWindowPosition();
        activePageIndex = -1;
        ChangePage();
    }

    void SetInitialWindowPosition()
    {
        LeanTween.rotate(gameObject, initialRotation, animationDuration).setEase(easeTypeOut);
        LeanTween.value(gameObject, roundedCorners.r.x, roundingAmount, animationDuration).setOnUpdate(SetCornersXZ);
        LeanTween.value(gameObject, roundingAmount, 0, animationDuration).setOnUpdate(SetCornersYW);
    }

    /// <summary>
    /// Set X and Z corner rounding values for the preview window
    /// </summary>
    /// <param name="value">Rounding value</param>
    void SetCornersXZ(float value)
    {
        roundedCorners.r.x = value;
        roundedCorners.r.z = value;
        roundedCorners.Refresh();
    }

    /// <summary>
    /// Set Y and W corner rounding values for the preview window
    /// </summary>
    /// <param name="value">Rounding value</param>
    void SetCornersYW(float value)
    {
        roundedCorners.r.y = value;
        roundedCorners.r.w = value;
        roundedCorners.Refresh();
    }

    /// <summary>
    /// Called whenever pointer enter or exit a menu button
    /// </summary>
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

    /// <summary>
    /// Callback when menu button is clicked
    /// </summary>
    /// <param name="clickedOption">Clicked menu button</param>
    void OnMenuOptionClicked(MenuButton clickedOption)
    {
        float animationTime = clickedOption.animatePreviewArea ? fullScreenAnimationDuration : 0;
        RectTransformHelper.FakeAnimateRectTransformTo(transform as RectTransform, fullScreenContentPage.transform as RectTransform);
        LeanTween.value(gameObject, 0, 1, animationTime).setOnComplete(clickedOption.ShowPageContent);
        //Hide preview pages
        ShowAllPreviewPages(false);
        EnableOnPointerListeners(false);
    }

    /// <summary>
    /// Show or hide the content in the Preview window
    /// </summary>
    /// <param name="show"></param>
    private void ShowAllPreviewPages(bool show)
    {
        for (int i = 0; i < previewPages.Length; i++)
        {
            previewPages[i].Visible = show;
        }
    }

    /// <summary>
    /// Restore the graphics when back to menu screen
    /// </summary>
    public void BackToMenu()
    {
        EnableOnPointerListeners(true);
        defaultpreviewPage.Visible = true;
        //Restore initial preview window size
        RectTransformHelper.FakeAnimateRectTransformTo(transform as RectTransform, originalTransform);
        SetInitialWindowPosition();
    }
}
