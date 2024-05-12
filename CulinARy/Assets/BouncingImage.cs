using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BouncingImage : MonoBehaviour
{
    public Image image; // Reference to the UI image component
    public float bounceHeight = 50f; // Height of the bounce
    public float bounceSpeed = 1f; // Speed of the bounce
    public float scaleMultiplier = 0.1f; // Scale multiplier for the bounce

    private RectTransform rectTransform; // Reference to the RectTransform of the image
    private Vector3 initialPosition; // Initial position of the image

    void Start()
    {
        // Get the RectTransform component
        rectTransform = image.GetComponent<RectTransform>();

        // Store the initial position of the image
        initialPosition = rectTransform.localPosition;

        // Start the bouncing coroutine
        StartCoroutine(Bounce());
    }

    IEnumerator Bounce()
    {
        while (true)
        {
            // Move up
            while (rectTransform.localPosition.y < initialPosition.y + bounceHeight)
            {
                rectTransform.localPosition += Vector3.up * bounceSpeed * Time.deltaTime;
                rectTransform.localScale += Vector3.one * scaleMultiplier * Time.deltaTime;
                yield return null;
            }

            // Move down
            while (rectTransform.localPosition.y > initialPosition.y)
            {
                rectTransform.localPosition -= Vector3.up * bounceSpeed * Time.deltaTime;
                rectTransform.localScale -= Vector3.one * scaleMultiplier * Time.deltaTime;
                yield return null;
            }
        }
    }
}
