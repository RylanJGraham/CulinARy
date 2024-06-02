using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    private Vector3 offset;
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // Ensure your AR camera is tagged as MainCamera
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Check if the left mouse button is pressed
        {
            offset = transform.position - GetMouseWorldPosition();
        }

        if (Input.GetMouseButton(0)) // Check if the left mouse button is held down
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
        }

        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                offset = transform.position - GetTouchWorldPosition(touch.position);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 newPosition = GetTouchWorldPosition(touch.position) + offset;
                transform.position = new Vector3(newPosition.x, newPosition.y, newPosition.z);
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = arCamera.WorldToScreenPoint(transform.position).z; // Ensure the depth is correct
        return arCamera.ScreenToWorldPoint(mousePoint);
    }

    private Vector3 GetTouchWorldPosition(Vector2 touchPosition)
    {
        Vector3 touchPoint = new Vector3(touchPosition.x, touchPosition.y, arCamera.WorldToScreenPoint(transform.position).z);
        return arCamera.ScreenToWorldPoint(touchPoint);
    }
}
