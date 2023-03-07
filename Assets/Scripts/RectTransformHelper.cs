using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RectTransformHelper
{
    class TransformData
    {
        public RectTransform toMove;
        public RectTransform target;
    }

    public static async void FakeAnimateRectTransformTo(RectTransform rectTransformToMove, RectTransform endTransform, float duration = 0.5f)
    {
        UniTaskCompletionSource animationEndSource = new UniTaskCompletionSource();

        TransformData animationData = new TransformData();
        animationData.toMove = rectTransformToMove;
        animationData.target = endTransform;

        LeanTween.value(rectTransformToMove.gameObject, 0, 1, duration).setOnUpdate(TweenPreviewSize, animationData)
            .setOnComplete(() => animationEndSource.TrySetResult());

        await animationEndSource.Task;
    }

    private static void TweenPreviewSize(float lerp, object animationData)
    {
        TransformData transformData = animationData as TransformData;
        RectTransform rectTransform = transformData.toMove;
        RectTransform fullScreenPageTransfrom = transformData.target;

        rectTransform.anchorMin = Vector2.Lerp(rectTransform.anchorMin, fullScreenPageTransfrom.anchorMin, lerp);
        rectTransform.anchorMax = Vector2.Lerp(rectTransform.anchorMax, fullScreenPageTransfrom.anchorMax, lerp);
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, fullScreenPageTransfrom.anchoredPosition, lerp);
        rectTransform.sizeDelta = Vector2.Lerp(rectTransform.sizeDelta, fullScreenPageTransfrom.sizeDelta, lerp);
    }

    public static RectTransform Clone(RectTransform toClone)
    {
        GameObject newObject = new GameObject(toClone.name + " (Clone)", new Type[] { typeof(RectTransform), typeof(CanvasRenderer) });

        newObject.transform.SetParent(toClone.parent, false);

        RectTransform objRectTransform = newObject.GetComponent<RectTransform>();

        objRectTransform.anchorMin = toClone.anchorMin;
        objRectTransform.anchorMax = toClone.anchorMax;
        objRectTransform.anchoredPosition = toClone.anchoredPosition;
        objRectTransform.sizeDelta = toClone.sizeDelta;
        objRectTransform.pivot = toClone.pivot;

        return newObject.transform as RectTransform;
    }
}
