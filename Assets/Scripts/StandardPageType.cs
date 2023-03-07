using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardPageType : PageType, IPageType
{
    public async override void ShowPageContent()
    {
        base.ShowPageContent();
        await fullScreenContentPage.ShowStandardContentPage();
        fullScreenContentPage.ResetWipeValue();
        BackButton.ReplaceListener(ShowMenu);
    }

    public async override void ShowMenu()
    {
        await fullScreenContentPage.ShowMenu(false);
        base.ShowMenu();
    }
}
