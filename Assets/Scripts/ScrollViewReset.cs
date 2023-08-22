using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewReset : MonoBehaviour
{
    //Scroll to beginning
    async void Start()
    {
        await UniTask.NextFrame();
        RectTransform rectTransform = (RectTransform)transform;
        Canvas.ForceUpdateCanvases();
        rectTransform.anchoredPosition = new Vector2(0, 0);
    }
}
