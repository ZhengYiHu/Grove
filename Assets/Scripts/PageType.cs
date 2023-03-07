using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageType : MonoBehaviour, IPageType
{
    [SerializeField] protected MainContentPage fullScreenContentPage;

    public virtual void ShowPageContent()
    {
        fullScreenContentPage.gameObject.SetActive(true);
    }

    public virtual void ShowMenu()
    {
        fullScreenContentPage.gameObject.SetActive(false);
    }
}
