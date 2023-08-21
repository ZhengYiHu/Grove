using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectPageType : PageType
{
    [SerializeField]
    public ProjectTemplate projectTemplate;
    MainContentPage mainContentPage;
    protected ContentPage contentPage;

    public override Color bgColor
    {
        get { return contentPage.bgColor; }
    }

    private void Start()
    {
        mainContentPage = FindFirstObjectByType<MainContentPage>();
    }

    public override UniTask ShowPageContent()
    {
        contentPage = Instantiate(projectTemplate.contentPage, mainContentPage.transform);
        BackButton.ReplaceListener(OnBackPressed);
        BackButton.SetInteractable(true);
        return new UniTask();
    }

    public override void OnBackPressed()
    {
        if (contentPage != null) Destroy(contentPage.gameObject);
        BackButton.ReplaceListener(async() =>
        {
            BackButton.instance.AnimateOut();
            mainContentPage.ShowMenu();
        });
    }
}
