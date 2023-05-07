using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPageType : PageType
{
    public async override UniTask ShowPageContent()
    {
        base.ShowPageContent();
        fullScreenContentPage.SetBlockRaycast(true);
        BackButton.SetInteractable(false);
        await fullScreenContentPage.ShowProject();
        contentPage = Instantiate(contentPagePrefab, fullScreenContentPage.transform);
        fullScreenContentPage.ResetWipeValue();
        BackButton.ReplaceListener(OnBackPressed);
        BackButton.SetInteractable(true);
    }

    public async override void OnBackPressed()
    {
        if (contentPage != null) Destroy(contentPage.gameObject);
        fullScreenContentPage.Show3DScene();
        BackButton.ReplaceListener(ShowMainMenu);
        fullScreenContentPage.SetBlockRaycast(false);
    }

    private async void ShowMainMenu()
    {
        BackButton.instance.AnimateOut();
        await fullScreenContentPage.ShowMenu();
        base.OnBackPressed();
    }

    public void ReplaceContentPage(ContentPage newPage)
    {
        contentPagePrefab = newPage;
    }
}
