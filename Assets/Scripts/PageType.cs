using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PageType : MonoBehaviour
{
    public abstract UniTask ShowPageContent();
    public abstract void OnBackPressed();
}
