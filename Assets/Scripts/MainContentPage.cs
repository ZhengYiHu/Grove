using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainContentPage : MonoBehaviour
{
    [SerializeField] Image bgImage;
    [SerializeField] GameObject[] objectsToDisableOnScene;

    [SerializeField] float animationDuration = 3f;
    [SerializeField] LeanTweenType wipeEase;
    Material wipeMaterial => bgImage.material;

    private void Awake()
    {
        float ratio = (float) bgImage.rectTransform.rect.height/ bgImage.rectTransform.rect.width;
        wipeMaterial.SetFloat("_Horizontal", ratio);
        wipeMaterial.SetFloat("_Vertical", 1);
        wipeMaterial.SetFloat("_Radius", 0);
    }

    Color bgColor;
    public async UniTask ShowPageWithAnimation()
    {
        UniTaskCompletionSource animationEndSource = new UniTaskCompletionSource();

        bgColor = wipeMaterial.GetColor("_TopTint");
        //Fade in material's transparency
        LeanTween.value(gameObject, 0, 1, 0.3f).setOnUpdate(TweenBGAlpha)
            .setOnComplete(() => animationEndSource.TrySetResult());

        await animationEndSource.Task;
    }

    private void TweenBGAlpha(float lerp)
    {
        bgColor.a = lerp;
        wipeMaterial.SetColor("_TopTint", bgColor);
    }

    [Button]
    public async UniTaskVoid Show3DScene()
    {
        await ShowPageWithAnimation();
        foreach (GameObject toDisable in objectsToDisableOnScene)
        {
            toDisable.SetActive(false);
        }
        WipeAnimation();
    }

    private void WipeAnimation()
    {
        LeanTween.value(gameObject, 0, 1, animationDuration)
            .setOnUpdate(TweenWipeRadius).setEase(wipeEase);
    }

    private void TweenWipeRadius(float lerp)
    {
        wipeMaterial.SetFloat("_Radius", lerp);
    }

    private void OnDisable()
    {
        //Reset Material Transparency
        bgColor.a = 0;
        wipeMaterial.SetColor("_TopTint", bgColor);
    }
}
