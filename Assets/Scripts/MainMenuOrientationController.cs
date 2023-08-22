using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOrientationController : MonoBehaviour
{
    bool previousOrientation;
    const float MenuAnchor = 0.6f;
    const float FullScreenAnchor = 1;
    const float BeginScreenAnchor = 0;
    [SerializeField]
    RectTransform menuTransform;
    [SerializeField]
    PreviewElement previewElement;

    RectTransform previewOriginalTransform => previewElement.originalTransform;
    RectTransform previewTransform => (RectTransform) previewElement.transform;

    private void Awake()
    {
        previousOrientation = !ScreenOrientationAdapter.isLandscape;
    }

    private void Update()
    {
        bool currentOrientation = ScreenOrientationAdapter.isLandscape;
        if (currentOrientation != previousOrientation)
        {
            previousOrientation = currentOrientation;
            if(currentOrientation)
            {
                LandscapeMode();
            }
            else
            {
                VerticalMode();
            }
        }
    }

    void VerticalMode()
    {
        menuTransform.anchorMax = new Vector2(FullScreenAnchor, MenuAnchor);
        previewTransform.anchorMin = new Vector2(BeginScreenAnchor, MenuAnchor);
        previewOriginalTransform.anchorMin = new Vector2(BeginScreenAnchor, MenuAnchor);
    }

    void LandscapeMode()
    {
        menuTransform.anchorMax = new Vector2(MenuAnchor, FullScreenAnchor);
        previewTransform.anchorMin = new Vector2(MenuAnchor, BeginScreenAnchor);
        previewOriginalTransform.anchorMin = new Vector2(MenuAnchor, BeginScreenAnchor);
    }
}
