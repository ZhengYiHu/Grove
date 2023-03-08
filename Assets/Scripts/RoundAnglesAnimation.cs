using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nobi.UiRoundedCorners;
using NaughtyAttributes;

public class RoundAnglesAnimation : MonoBehaviour
{
    [SerializeField] float amount;
    [SerializeField] float duration;
    [SerializeField] LeanTweenType loopType;
    [SerializeField] LeanTweenType easeType;
    [SerializeField] ImageWithRoundedCorners roundedCorners;

    void Start()
    {
        PlayAnimation();
    }

    void PlayAnimation()
    {
        LeanTween.value(gameObject, roundedCorners.radius, amount, duration).setOnUpdate(RoundCorners);
    }

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    void ReplayAnimation()
    {
        PlayAnimation();
    }

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    void Refresh()
    {
        roundedCorners.Refresh();
    }

    void RoundCorners(float amount)
    {
        roundedCorners.radius = amount;
        roundedCorners.Validate();
        roundedCorners.Refresh();
    }

}
