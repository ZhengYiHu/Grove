using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    [SerializeField] AnimationMode mode;
    [SerializeField] float amount;
    [SerializeField] float duration;
    [SerializeField] LeanTweenType loopType;
    [SerializeField] LeanTweenType easeType;

    void Start()
    {
        PlayAnimation();
    }

    void PlayAnimation()
    {
        switch (mode)
        {
            case AnimationMode.Scale:
                LeanTween.scale(gameObject, new Vector3(0, 0, amount), duration).setLoopType(loopType).setEase(easeType);
                break;
            case AnimationMode.Rotation:
                transform.rotation = Quaternion.Euler(new Vector3(0,0,-amount/2));
                LeanTween.rotate(gameObject, new Vector3(0, 0, amount / 2), duration).setLoopType(loopType).setEase(easeType);
                break;
            default:
                break;
        }
    }

    [Button(enabledMode: EButtonEnableMode.Playmode)]
    void ReplayAnimation()
    {
        LeanTween.pauseAll();
        PlayAnimation();
    }
}

enum AnimationMode
{
   Scale,
   Rotation
}

