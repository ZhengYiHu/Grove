using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectView : MonoBehaviour
{
    [SerializeField]
    ProjectPageType page;
    [SerializeField]
    TextMeshProUGUI title;
    [SerializeField]
    TextMeshProUGUI description;
    [SerializeField]
    SpriteFromURL previewImage;

    public void Start()
    {
        ProjectTemplate template = page.projectTemplate;

        title.text = template.title;
        description.text = template.subtitle;
    }

    [Button]
    private void Reset()
    {
        ProjectTemplate template = page.projectTemplate;
        previewImage.imageName = template.previewImage.name;
    }
}
