using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] PreviewElementPage associatedPage;
    [SerializeField] Image outline;
    public static Action<MenuButton> OnButtonEnter;
    public static Action<MenuButton> OnButtonExit;
    public static Action<MenuButton> OnButtonClick;

    [SerializeField] LeanTweenType inType;
    [SerializeField] LeanTweenType outType;
    [SerializeField] float animationDuration = 0.5f;
    [SerializeField] float scaleRatio = 1.2f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector3(scaleRatio, scaleRatio, scaleRatio), animationDuration).setEase(inType);
        outline.gameObject.SetActive(true);
        OnButtonEnter?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, Vector3.one, animationDuration).setEase(inType);
        outline.gameObject.SetActive(false);
        OnButtonExit?.Invoke(this);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClick.Invoke(this);
    }

    public PreviewElementPage GetAssociatedPage()
    {
        return associatedPage;
    }

}
