using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPageType : PageType
{
    public async override void ShowPageContent()
    {
        base.ShowPageContent();
        await fullScreenContentPage.ShowProject();
        contentPage = Instantiate(contentPagePrefab, fullScreenContentPage.transform);
        fullScreenContentPage.ResetWipeValue();
        BackButton.ReplaceListener(OnBackPressed);
    }

    public async override void OnBackPressed()
    {
        if (contentPage != null) Destroy(contentPage.gameObject);
        fullScreenContentPage.Show3DScene();
        BackButton.ReplaceListener(ShowMainMenu);
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
