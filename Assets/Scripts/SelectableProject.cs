using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableProject : MonoBehaviour
{ 
    [SerializeField]
    Transform modelParent;
    [SerializeField]
    GameObject modelPrefab;
    [SerializeField]
    public Sprite previewImage;
    [SerializeField]
    public string title;
    [ResizableTextArea]
    public string descritpion;
    [SerializeField]
    public ContentPage contentPage;


    private void Start()
    {
        if(modelParent.childCount == 0) Instantiate(modelPrefab, modelParent);
    }
}
