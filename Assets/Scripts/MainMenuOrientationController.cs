using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuOrientationController : MonoBehaviour
{
    bool previousOrientation;
    const float MenuAnchor = 0.6f;
    const float PreviewAnchor = 0.5f;
    const float FullScreenAnchor = 1;
    const float BeginScreenAnchor = 0;
    [SerializeField]
    RectTransform menuTransform;
    [SerializeField]
    RectTransform previewTransform;

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
        previewTransform.anchorMin = new Vector2(BeginScreenAnchor, PreviewAnchor);
    }

    void LandscapeMode()
    {
        menuTransform.anchorMax = new Vector2(MenuAnchor, FullScreenAnchor);
        previewTransform.anchorMin = new Vector2(MenuAnchor, BeginScreenAnchor);
    }
}
