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
        BackButton.ReplaceListener(ShowMenu);
    }

    public async override void ShowMenu()
    {
        await fullScreenContentPage.ShowMenu(false);
        if (contentPage != null) Destroy(contentPage.gameObject);
        base.ShowMenu();
    }
}
