using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Movement : MonoBehaviour
{
    private Vector3 _mousePos;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _mousePos = Input.mousePosition;
            Debug.Log(_mousePos.x);
            Debug.Log(_mousePos.y);
        }
    }
}
