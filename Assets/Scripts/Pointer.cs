using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    int layerMask = 1 << 3; //Collision layer for SelectableObjects

    GameObject target;
    private void Update()
    {
        //Raycast downwards
        if (Physics.Raycast(transform.position, Vector3.down, hitInfo: out RaycastHit hit, 3, layerMask: layerMask))
        {
            if(hit.collider.gameObject != target)
            {
                target = hit.collider.gameObject;
                //Get collider data
                if(target.TryGetComponent<SelectableProject>(out var selectableProject))
                {
                    ScreenOrientationAdapter.preview.ShowProject(selectableProject);
                    ScreenOrientationAdapter.disabledPreview.ShowProject(selectableProject);
                }

                ScreenOrientationAdapter.preview.fadeIn();
                ScreenOrientationAdapter.disabledPreview.fadeIn();
            }
        }
        else
        {
            target = null;
            ScreenOrientationAdapter.preview.fadeOut();
            ScreenOrientationAdapter.disabledPreview.fadeOut();
        }
    }
}
