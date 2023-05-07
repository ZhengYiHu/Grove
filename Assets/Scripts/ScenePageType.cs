using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePageType : PageType
{
    public override UniTask ShowPageContent()
    {
        fullScreenContentPage.Show3DScene();
        fullScreenContentPage.ResetWipeValue();
        BackButton.ReplaceListener(OnBackPressed);

        return base.ShowPageContent();
    }

    public async override void OnBackPressed()
    {
        BackButton.instance.AnimateOut();
        await fullScreenContentPage.ShowMenu();
        base.OnBackPressed();
    }
}
