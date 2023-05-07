using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageType : MonoBehaviour, IPageType
{
    [SerializeField] protected MainContentPage fullScreenContentPage;
    [SerializeField] protected ContentPage contentPagePrefab;

    protected ContentPage contentPage;

    public virtual UniTask ShowPageContent()
    {
        UniTaskCompletionSource animationCompleteSource = new UniTaskCompletionSource();
        fullScreenContentPage.gameObject.SetActive(true);
        animationCompleteSource.TrySetResult();
        return animationCompleteSource.Task;
    }

    public virtual void OnBackPressed()
    {
        fullScreenContentPage.gameObject.SetActive(false);
    }
}
