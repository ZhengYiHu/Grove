using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageType : MonoBehaviour, IPageType
{
    [SerializeField] protected MainContentPage fullScreenContentPage;
    [SerializeField] protected ContentPage contentPagePrefab;

    protected ContentPage contentPage;

    public virtual void ShowPageContent()
    {
        fullScreenContentPage.gameObject.SetActive(true);
    }

    public virtual void OnBackPressed()
    {
        fullScreenContentPage.gameObject.SetActive(false);
    }
}
