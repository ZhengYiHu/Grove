using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle3DAnimation : MonoBehaviour
{
    [SerializeField] float distance = 0.3f;
    [SerializeField] bool rotate = true;
    [ShowIf("rotate")]
    [SerializeField] Vector3 pivot = Vector3.up;
    [ShowIf("rotate")]
    [SerializeField] float rotationSpeed = 1;
    [ShowIf("rotate")]
    [SerializeField] bool objSpace = true;
    void Start()
    {
        transform.LeanMoveLocalY(transform.localPosition.y - distance, 2).setLoopPingPong();
        if (rotate)
        {
            if(objSpace)
            {
                transform.LeanRotateAroundLocal(pivot, 360, 10 / rotationSpeed).setLoopClamp();
            }
            //world Space Rotation
            else
            {
                transform.LeanRotateAround(pivot, 360, 10 / rotationSpeed).setLoopClamp();
            }
        }
    }
}
