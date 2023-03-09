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
    [SerializeField] ImageWithIndependentRoundedCorners roundedCorners;

    void Start()
    {
        PlayAnimation();
    }

    void PlayAnimation()
    {
        LeanTween.value(gameObject, 0, amount * 4, duration).setOnUpdate(RoundCorners).setLoopType(loopType).setEase(easeType);
    }

    void RoundCorners(float currentAmount)
    {
        roundedCorners.r.x = Mathf.Clamp(amount - (Mathf.Abs(amount - currentAmount)),0, amount);
        roundedCorners.r.y = Mathf.Clamp(((amount * 2) - (Mathf.Abs(amount * 2 - currentAmount))) - amount, 0, amount);
        roundedCorners.r.z = Mathf.Clamp(((amount * 3) - (Mathf.Abs(amount * 3 - currentAmount))) - (amount * 2), 0, amount);
        roundedCorners.r.w = Mathf.Clamp((Mathf.Abs(amount * 2 - currentAmount)) - amount, 0, amount);
        roundedCorners.Validate();
        roundedCorners.Refresh();
    }

}
