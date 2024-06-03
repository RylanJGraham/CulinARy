using UnityEngine;

public class ToggleVisibilityBravas : MonoBehaviour
{
    public GameObject targetGameObject;

    void Start()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    // Public method to show the GameObject
    public void ShowGameObject()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(true);
        }
    }

    // Public method to hide the GameObject
    public void HideGameObject()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    // Public method to toggle the GameObject's visibility
    public void ToggleGameObject()
    {
        if (targetGameObject != null)
        {
            bool isActive = targetGameObject.activeSelf;
            targetGameObject.SetActive(!isActive);
        }
    }
}
