using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Page", menuName = "ProjectPage", order = 1)]
public class ProjectTemplate : ScriptableObject
{
    [SerializeField] public string title = "Title";
    [SerializeField] public string subtitle = "Subtitle";
    [SerializeField] public TextAsset bodyAsset;
    [SerializeField] public Sprite previewImage;
    [SerializeField] public ContentPage contentPage;
}
