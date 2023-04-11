using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PointerScript : MonoBehaviour
{

    void Update()
    {
        //if left click 
        //Cast a ray
        //if hit floor
        //set targetDestination(tell playertomove here)

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            RaycastHit hitInfo;
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray rayOrigin = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                if (hitInfo.collider.tag == "Ground")
                {
                    Player._targetDestination = hitInfo.point;
                }
            }
        }

    }
}
