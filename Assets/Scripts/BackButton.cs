using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] PreviewElement previewElement;
    [SerializeField] Button button;
    private static Action OnBackClicked;

    private void Awake()
    {
        button.onClick.AddListener(() => OnBackClicked.Invoke());
    }

    public static void ReplaceListener(Action newAction)
    {
        OnBackClicked = null;
        OnBackClicked = newAction;
    }
}
