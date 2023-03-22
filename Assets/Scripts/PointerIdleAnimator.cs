using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerIdleAnimator : MonoBehaviour
{
    [SerializeField] float distance = 0.3f;
    void Start()
    {
        transform.LeanMove(new Vector3(transform.position.x, transform.position.y + distance, transform.position.z), 1.3f).setLoopPingPong();
        transform.LeanRotateAroundLocal(Vector3.up, 360, 10).setLoopClamp();
    }
}
