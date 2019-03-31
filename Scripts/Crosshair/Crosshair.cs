using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.CrossPlatformInput;

public class Crosshair : MonoBehaviour
{    
    public static Vector3 currentPos;
    private Vector3 newPos;

    public void LateUpdate()
    {
        MoveCrosshair();
    }

    private void MoveCrosshair()
    {
        float verticalBorder = 4f;
        float horizontalBorder = 6.5f;
        if (CannonController.isCannonChoosen != true) return;

        float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
        float verticalInput = CrossPlatformInputManager.GetAxis("Vertical");        

        currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        newPos = new Vector3(horizontalBorder * horizontalInput, verticalBorder * verticalInput, 0);       
 

        if (horizontalInput != 0 || verticalInput != 0)
        {
            transform.position = Vector3.Lerp(currentPos, newPos, CannonController.speed * 0.5f *  Time.deltaTime);            
        }

    }
}
