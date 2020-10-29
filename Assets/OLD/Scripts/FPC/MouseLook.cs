using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum rotationAxes
    {
        MouseXY,
        MouseX,
        MouseY
    }

    public rotationAxes axes = rotationAxes.MouseXY;
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    private float xRotation;
    private float yRotation;

    public float minimumVert = -45.0f; 
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>(); 
        if (body != null)
            body.freezeRotation = true;
    }

    void Update()
    {
        xRotation = Input.GetAxis("Mouse X") * sensitivityHor;
        yRotation = Input.GetAxis("Mouse Y") * sensitivityVert;

        switch (axes)
        {
            // Horizontal rotation
            case rotationAxes.MouseX: transform.Rotate(0, xRotation, 0); break;

            // Vertical rotation
            case rotationAxes.MouseY:
            {
                _rotationX -= yRotation;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

            } break;

            // Comby rotation X+Y
            case rotationAxes.MouseXY:
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert; 
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                } break;
        }
    }
}
