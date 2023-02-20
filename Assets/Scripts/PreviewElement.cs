using Nobi.UiRoundedCorners;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewElement : MonoBehaviour
{
    [SerializeField] AnimationCurve animationCurve;
    [SerializeField] ImageWithIndependentRoundedCorners roundedCorners;
    [Space, Header("Settings")] 
    [SerializeField] float rotationAmount = 5;
    [SerializeField] float roundingAmount = 70;
    [SerializeField] float animationDuration = 0.3f;
    [SerializeField] LeanTweenType easeTypeOut;

    Vector3 initialRotation;

    private void Awake()
    {
        MenuButton.OnButtonEnter += ShakeToFocus;
        MenuButton.OnButtonExit += LoseFocus;
        initialRotation = gameObject.transform.rotation.eulerAngles;
    }

    void ShakeToFocus(MenuButton hoveredButton)
    {
        LeanTween.rotate(gameObject, gameObject.transform.rotation.eulerAngles + new Vector3(0, 0, rotationAmount), animationDuration).setEase(animationCurve);
        LeanTween.value(gameObject, roundingAmount, 0f, animationDuration).setOnUpdate(SetCornersXZ);
        LeanTween.value(gameObject, roundedCorners.r.y, roundingAmount, animationDuration).setOnUpdate(SetCornersYW);
    }

    void LoseFocus(MenuButton hoveredButton)
    {
        LeanTween.rotate(gameObject, initialRotation, animationDuration).setEase(easeTypeOut);
        LeanTween.value(gameObject, roundedCorners.r.x, roundingAmount, animationDuration).setOnUpdate(SetCornersXZ);
        LeanTween.value(gameObject, roundingAmount, 0, animationDuration).setOnUpdate(SetCornersYW);
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

    private void OnDestroy()
    {
        MenuButton.OnButtonEnter -= ShakeToFocus;
    }
}
