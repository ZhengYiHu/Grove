using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOrientationAdapter : MonoBehaviour
{
    static public bool isLandscape;

    private void Update()
    {
        isLandscape = Screen.width > Screen.height;
    }
}
