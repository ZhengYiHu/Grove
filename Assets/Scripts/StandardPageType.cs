using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPageType : PageType
{
    [SerializeField]
    private ContentPage contentPagePrefab;
    [SerializeField]
    public ProjectTemplate projectTemplate;
    [SerializeField]
    private MainContentPage fullScreenContentPage;

    public override UniTask ShowPageContent()
    {
        UniTaskCompletionSource animationCompleteSource = new UniTaskCompletionSource();
        fullScreenContentPage.SetBlockRaycast(true);
        fullScreenContentPage.ShowStandardContentPage();
        fullScreenContentPage.ResetWipeValue();

        //Instantiate content Page
        Instantiate(contentPagePrefab, fullScreenContentPage.transform);
        BackButton.ReplaceListener(OnBackPressed);

        fullScreenContentPage.gameObject.SetActive(true);
        animationCompleteSource.TrySetResult();
        return animationCompleteSource.Task;
    }

    public override async void OnBackPressed()
    {
        BackButton.instance.AnimateOut();
        await fullScreenContentPage.ShowMenu(false);
    }
}
