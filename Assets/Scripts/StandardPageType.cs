using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPageType : PageType
{
    [SerializeField]
    private ContentPage contentPagePrefab;
    [SerializeField]
    private MainContentPage fullScreenContentPage;

    public override Color bgColor {
        get { return contentPagePrefab.bgColor; }
    }

    public override UniTask ShowPageContent()
    {
        UniTaskCompletionSource animationCompleteSource = new UniTaskCompletionSource();
        fullScreenContentPage.SetBlockRaycast(true);
        fullScreenContentPage.ShowStandardContentPage();

        //Instantiate content Page
        Instantiate(contentPagePrefab, fullScreenContentPage.transform);
        BackButton.ReplaceListener(OnBackPressed);

        fullScreenContentPage.gameObject.SetActive(true);
        animationCompleteSource.TrySetResult();
        return animationCompleteSource.Task;
    }

    public override void OnBackPressed()
    {
        BackButton.instance.AnimateOut();
        fullScreenContentPage.ShowMenu();
    }
}
