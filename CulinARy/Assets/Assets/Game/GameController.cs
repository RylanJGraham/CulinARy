using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public RectTransform potato;
    public RectTransform knife;
    public RectTransform cuttingBoard;
    public TextMeshProUGUI messageText;
    public Sprite cutPotatoSprite; // Assign the CutPotato sprite in the Inspector

    private bool isPotatoPlaced = false;
    private Image potatoImage;

    private void Start()
    {
        knife.GetComponent<DraggableObjectModified>().enabled = false; // Disable knife dragging initially
        potatoImage = potato.GetComponent<Image>();
    }

    public void CheckPosition(RectTransform draggedObject)
    {
        if (draggedObject == potato)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(cuttingBoard, potato.position, null))
            {
                isPotatoPlaced = true;
                knife.GetComponent<DraggableObjectModified>().enabled = true; // Enable knife dragging
                UpdateMessage("Potato is on the cutting board. You can move the knife now.");
            }
            else
            {
                UpdateMessage("Ingredient must be on the cutting board before moving forward.");
            }
        }
    }

    public bool IsPotatoPlaced()
    {
        return isPotatoPlaced;
    }

    public void UpdateMessage(string message)
    {
        messageText.text = message;
    }

    public void ChangePotatoSprite()
    {
        potatoImage.sprite = cutPotatoSprite;
    }
}
