using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    int layerMask = 1 << 3; //Collision layer for SelectableObjects
    [SerializeField] CanvasGroup previewWindowCanvasGroup;

    GameObject target;
    private void Update()
    {
        //Raycast downwards
        if (Physics.Raycast(transform.position, Vector3.down, hitInfo: out RaycastHit hit, 3, layerMask: layerMask))
        {
            if(hit.collider.gameObject != target)
            {
                target = hit.collider.gameObject;
                LeanTween.alphaCanvas(previewWindowCanvasGroup, 1, 0.3f);
            }
        }
        else
        {
            target = null;
            LeanTween.alphaCanvas(previewWindowCanvasGroup, 0, 0.3f);
        }
    }
}
