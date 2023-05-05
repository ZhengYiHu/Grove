using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ProjectPage : MonoBehaviour
{
    [SerializeField, Expandable] ProjectTemplate template;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI subtitle;

    [Button]
    public void PopulateContentFromTemplate()
    {
        title.text = template.title;
        subtitle.text = template.subtitle;
    }

    private void OnValidate()
    {
        PopulateContentFromTemplate();
    }
}
