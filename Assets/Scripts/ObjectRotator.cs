using UnityEngine;
using System.Collections;
using NaughtyAttributes;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float _sensitivity;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    [ShowNonSerializedField] private Vector3 _rotation;
    private bool _isRotating;

    void Start()
    {
        _rotation = Vector3.zero;
    }

    void FixedUpdate()
    {
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;
            // rotate
            rb.AddTorque(_rotation, ForceMode.Impulse);

            // store mouse
            _mouseReference = Input.mousePosition;
        }
    }

    void OnMouseDown()
    {
        // rotating flag
        _isRotating = true;

        // store mouse
        _mouseReference = Input.mousePosition;
    }

    void OnMouseUp()
    {
        // rotating flag
        _isRotating = false;
    }

}