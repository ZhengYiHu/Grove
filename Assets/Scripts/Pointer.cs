using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    int layerMask = 1 << 3; //Collision layer for SelectableObjects
    [SerializeField] ScenePreview scenePreview;

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
                    scenePreview.ShowProject(selectableProject);
                }

                scenePreview.fadeIn();
            }
        }
        else
        {
            target = null;
            scenePreview.fadeOut();
        }
    }
}
