using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<MenuButton> OnButtonEnter;
    public static Action<MenuButton> OnButtonExit;

    [SerializeField] LeanTweenType inType;
    [SerializeField] LeanTweenType outType;
    [SerializeField] float animationDuration = 0.5f;
    [SerializeField] float scaleRatio = 1.2f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, new Vector3(scaleRatio, scaleRatio, scaleRatio), animationDuration).setEase(inType);
        OnButtonEnter?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(gameObject, Vector3.one, animationDuration).setEase(inType);
        OnButtonExit?.Invoke(this);
    }
}
