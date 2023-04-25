using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePageType : PageType
{
    public override void ShowPageContent()
    {
        base.ShowPageContent();
        fullScreenContentPage.Show3DScene();
        fullScreenContentPage.ResetWipeValue();
        BackButton.ReplaceListener(OnBackPressed);
    }

    public async override void OnBackPressed()
    {
        BackButton.instance.AnimateOut();
        await fullScreenContentPage.ShowMenu();
        base.OnBackPressed();
    }
}
