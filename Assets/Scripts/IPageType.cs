using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPageType
{
    public UniTask ShowPageContent();
    public void OnBackPressed();
}
