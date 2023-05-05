using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableProject : MonoBehaviour
{ 
    [SerializeField]
    Transform modelParent;
    [SerializeField, Expandable]
    public ProjectTemplate projectTemplate;
    [SerializeField]
    public ContentPage contentPage;


    private void Start()
    {
        if(modelParent.childCount == 0) Instantiate(projectTemplate.modelPrefab, modelParent);
    }
}
