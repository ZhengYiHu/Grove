using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainContentPage : MonoBehaviour
{
    [SerializeField] PreviewElement previewElement;
    [SerializeField] Image bgImage;
    [SerializeField] GameObject[] objectsToDisableOnScene;
    [SerializeField] GameObject[] objectsToEnableOnScene;

    [SerializeField] GameObject[] objectsToDisableOnStandard;
    [SerializeField] GameObject[] objectsToEnableOnStandard;

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

    public async UniTask Show3DScene()
    {
        ShowSceneGraphics(true);
        WipeAnimation(true).Forget();
    }

    public async UniTask ShowStandardContentPage()
    {
        ShowStandardGraphics(true);
    }

    public async UniTask ShowMenu(bool withWipe = true)
    {
        if(withWipe) await WipeAnimation(false);
        previewElement.BackToMenu();
        ShowSceneGraphics(false);
        ShowStandardGraphics(false);
        if (withWipe) WipeAnimation(true).Forget();
    }

    private void ShowSceneGraphics(bool active)
    {
        foreach (GameObject toDisable in objectsToDisableOnScene)
        {
            toDisable.SetActive(!active);
        }
        foreach (GameObject toEnable in objectsToEnableOnScene)
        {
            toEnable.SetActive(active);
        }
    }

    private void ShowStandardGraphics(bool active)
    {
        foreach (GameObject toDisable in objectsToDisableOnStandard)
        {
            toDisable.SetActive(!active);
        }
        foreach (GameObject toEnable in objectsToEnableOnStandard)
        {
            toEnable.SetActive(active);
        }
    }

    private async UniTask WipeAnimation(bool show)
    {
        UniTaskCompletionSource animationEndSource = new UniTaskCompletionSource();

        int from = show ? 0 : 1;
        int to = show ? 1 : 0;
        LeanTween.value(gameObject, from, to, animationDuration)
            .setOnUpdate(TweenWipeRadius).setEase(wipeEase).setOnComplete(() => animationEndSource.TrySetResult());

        await animationEndSource.Task;
    }

    private void TweenWipeRadius(float lerp)
    {
        wipeMaterial.SetFloat("_Radius", lerp);
    }

    public void ResetWipeValue()
    {
        wipeMaterial.SetFloat("_Radius", 0);
    }
}
