using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle3DAnimation : MonoBehaviour
{
    [SerializeField] float distance = 0.3f;
    [SerializeField] Vector3 pivot = Vector3.up;
    void Start()
    {
        transform.LeanMoveLocalY(transform.localPosition.y - distance, 2).setLoopPingPong();
        transform.LeanRotateAroundLocal(pivot, 360, 10).setLoopClamp();
    }
}
