using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool _isLeftMousePressed;
    //check user input

    //cast a ray at mouse position
    // check if we hit a cube
    //cheng the color the object we hit.

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _isLeftMousePressed = true;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
