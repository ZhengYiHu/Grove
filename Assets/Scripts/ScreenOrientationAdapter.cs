using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationAdapter : MonoBehaviour
{
    static public bool isLandscape;
    [SerializeField] ScenePreview scenePreviewLandscape;
    [SerializeField] ScenePreview scenePreviewVertical;

    static public ScenePreview preview;
    static public ScenePreview disabledPreview;

    private void Update()
    {
        isLandscape = Screen.width > Screen.height;
        scenePreviewLandscape.gameObject.SetActive(isLandscape);
        scenePreviewVertical.gameObject.SetActive(!isLandscape);
        preview = isLandscape ? scenePreviewLandscape : scenePreviewVertical;
        disabledPreview = isLandscape ? scenePreviewVertical : scenePreviewLandscape;
    }
}
