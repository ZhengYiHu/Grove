using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI)), ExecuteInEditMode]
public class Hyperlink : MonoBehaviour
{
    [ResizableTextArea]
    public string text;
    [ResizableTextArea]
    public string link;

    TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        if (textMeshPro == null) textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    [Button]
    void ParseHyperlink()
    {
        textMeshPro.text = $"<color=#54A0FFFF><u><link=\"{link}\"><b>{text}</b></link></color></u>";
    }
}