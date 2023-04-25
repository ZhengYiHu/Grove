using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenePreview : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    TextMeshProUGUI description;
    [SerializeField]
    Image previewImage;
    [SerializeField]
    CanvasGroup canvasGroup;
    [SerializeField]
    ProjectPageType projectPage;

    public void ShowProject(SelectableProject project)
    {
        title.text = project.title;
        description.text = project.descritpion;
        previewImage.sprite = project.previewImage;
        projectPage.ReplaceContentPage(project.contentPage);
    }

    public void fadeIn()
    {
        LeanTween.alphaCanvas(canvasGroup, 1, 0.3f);
    }

    public void fadeOut()
    {
        LeanTween.alphaCanvas(canvasGroup, 0, 0.3f);
    }
}
