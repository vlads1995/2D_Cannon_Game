using UnityEngine;

public class Crosshair : CannonController
{    
    public static Vector3 currentPos;

    private Vector3 _newPos;

    public void LateUpdate()
    {
        MoveCrosshair();
    }

    private void MoveCrosshair()
    {
        if (isCannonChoosen != true) return;

        const float speedCorrecter = 0.2f;
        const float posCorrecter = 3f;

        foreach (var touchscreen in moveTouches)
        {
            if ((touchscreen.phase == TouchPhase.Moved) && (touchscreen.position.x > Screen.width / 2))
            {
                currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                _newPos = new Vector3(touchscreen.deltaPosition.x * posCorrecter, touchscreen.deltaPosition.y * posCorrecter, 0);

                if ((touchscreen.deltaPosition.y != 0) || (touchscreen.deltaPosition.x != 0))
                {
                    transform.position = Vector3.Lerp(currentPos, _newPos, Speed * Time.deltaTime * speedCorrecter);
                }
            }

        }

    }
}
