using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LinkButton : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] Button button;
    protected virtual string fullLink => url;

    private void Awake()
    {
        button.onClick.AddListener(OpenLink);
    }

    void OpenLink()
    {
        Application.OpenURL(fullLink);
    }
}
