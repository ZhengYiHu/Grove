using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainContentPage : MonoBehaviour
{
    [SerializeField] PreviewElement previewElement;
    [SerializeField] Image bgImage;
    [SerializeField] BackButton backButton;
    [SerializeField] CanvasGroup canvasGroup;

    public void ShowMenu()
    {
        previewElement.BackToMenu();
        //Destroy all instantiated pages
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        backButton.gameObject.SetActive(false);
        gameObject.SetActive(false);
        SetBlockRaycast(false);
    }

    public void ShowStandardContentPage()
    {
        backButton.gameObject.SetActive(true);
    }

    public void SetBlockRaycast(bool blockRaycast)
    {
        canvasGroup.blocksRaycasts = blockRaycast;
    }
}
