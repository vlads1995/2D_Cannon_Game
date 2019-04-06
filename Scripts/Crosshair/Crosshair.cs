using UnityEngine;

public class Crosshair : CannonController
{    
    public static Vector3 CurrentPos;

    private Vector3 _newPos;

    public void LateUpdate()
    {
        MoveCrosshair();
    }

    private void MoveCrosshair()
    {
        if (IsCannonChoosen != true || MoveTouches == null) return;

        const float speedCorrecter = 0.2f;
        const float posCorrecter = 3f;

        foreach (var touchscreen in MoveTouches)
        {
            if (touchscreen.phase == TouchPhase.Moved && touchscreen.position.x > Screen.width / 2)
            {
                CurrentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                _newPos = new Vector3(touchscreen.deltaPosition.x * posCorrecter, touchscreen.deltaPosition.y * posCorrecter, 0);

                if (touchscreen.deltaPosition != Vector2.zero)
                {
                    transform.position = Vector3.Lerp(CurrentPos, _newPos, Speed * Time.deltaTime * speedCorrecter);
                }
            }

        }

    }
}
