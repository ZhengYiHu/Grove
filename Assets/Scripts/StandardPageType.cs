using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPageType : PageType, IPageType
{
    public override void ShowPageContent()
    {
        base.ShowPageContent();
        fullScreenContentPage.ShowStandardContentPage();
        fullScreenContentPage.ResetWipeValue();

        //Instantiate content Page
        contentPage = Instantiate(contentPagePrefab, fullScreenContentPage.transform);
        BackButton.ReplaceListener(OnBackPressed);
    }

    public async override void OnBackPressed()
    {
        BackButton.instance.AnimateOut();
        await fullScreenContentPage.ShowMenu(false);
        if (contentPage != null) Destroy(contentPage.gameObject);
        base.OnBackPressed();
    }
}
