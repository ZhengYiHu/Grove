using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainContentPage : MonoBehaviour
{
    [SerializeField] PreviewElement previewElement;
    [SerializeField] Image bgImage;
    [SerializeField] BackButton backButton;
    [SerializeField] CanvasGroup canvasGroup;
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

    public async UniTask ShowMenu(bool withWipe = true)
    {
        if(withWipe) await WipeAnimation(false);
        previewElement.BackToMenu();
        if (withWipe) WipeAnimation(true).Forget();

        //Destroy all instantiated pages
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        backButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        SetBlockRaycast(false);
    }

    public void ShowStandardContentPage()
    {
        backButton.gameObject.SetActive(true);
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

    public void SetBlockRaycast(bool blockRaycast)
    {
        canvasGroup.blocksRaycasts = blockRaycast;
    }
}
