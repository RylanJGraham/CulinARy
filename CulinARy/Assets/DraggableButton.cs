using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableButton : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform parentRectTransform;
    private RectTransform canvasRectTransform;
    private Vector2 pointerOffset;
    private Vector2 minPosition;
    private Vector2 maxPosition;
    private Vector2 lastPointerPosition;

    void Start()
    {
        // Get the RectTransform components of the parent image and the canvas
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        // Calculate the boundaries of the canvas
        minPosition = canvasRectTransform.rect.min;
        maxPosition = canvasRectTransform.rect.max - parentRectTransform.rect.size;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Calculate the pointer offset from the center of the parent image
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, eventData.position, eventData.pressEventCamera, out pointerOffset);
        lastPointerPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the new position of the parent image
        Vector2 localPointerPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, eventData.position, eventData.pressEventCamera, out localPointerPosition);

        // Calculate the difference in pointer position since the last frame
        Vector2 pointerDelta = eventData.position - lastPointerPosition;
        lastPointerPosition = eventData.position;

        // Adjust the position by adding the pointer delta
        localPointerPosition -= pointerOffset;
        localPointerPosition += pointerDelta;

        // Clamp the position within the canvas bounds
        localPointerPosition.x = Mathf.Clamp(localPointerPosition.x, minPosition.x, maxPosition.x);
        localPointerPosition.y = Mathf.Clamp(localPointerPosition.y, minPosition.y, maxPosition.y);

        // Set the position of the parent image
        parentRectTransform.localPosition = localPointerPosition;
    }
}
