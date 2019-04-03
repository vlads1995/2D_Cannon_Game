using UnityEngine;

public class Crosshair : CannonController
{    
    public static Vector3 currentPos;

    private Vector3 newPos;

    public void LateUpdate()
    {
        MoveCrosshair();
    }

    private void MoveCrosshair()
    {
        float speedCorrecter = 0.2f;
        float posCorrecter = 3f;

        if (isCannonChoosen != true) return;

        foreach (var currenttouch in moveTouches)
        {
            if (currenttouch.phase == TouchPhase.Moved && currenttouch.position.x > Screen.width / 2)
            {
                currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                newPos = new Vector3(currenttouch.deltaPosition.x * posCorrecter, currenttouch.deltaPosition.y * posCorrecter, 0);

                if (currenttouch.deltaPosition.y != 0 || currenttouch.deltaPosition.x != 0)
                {
                    transform.position = Vector3.Lerp(currentPos, newPos, _speed * Time.deltaTime * speedCorrecter);
                }
            }

        }

    }
}
