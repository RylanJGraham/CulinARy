using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObjectModified : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private GameController gameController;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
        canvas = GetComponentInParent<Canvas>();
        gameController = FindObjectOfType<GameController>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Empty for now
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameObject.name == "Knife" && !gameController.IsPotatoPlaced())
        {
            gameController.UpdateMessage("Potato must be on the cutting board before moving the knife.");
            return;
        }
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (gameObject.name == "Knife" && !gameController.IsPotatoPlaced())
        {
            return;
        }

        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out localPoint))
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        gameController.CheckPosition(rectTransform);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name == "Knife" && other.gameObject == gameController.potato.gameObject)
        {
            gameController.ChangePotatoSprite();
        }
    }
}
