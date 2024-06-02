using UnityEngine;
using UnityEngine.UI;

public class DestroyableGameObject : MonoBehaviour
{
    public float destroyTime = 10f;
    public int pointValue = 1;

    private bool destroyed = false;
    private float timer = 0f;
    private static Slider scoreSlider; // Changed to static to ensure one instance shared across all objects

    void Start()
    {
        // Check if the slider reference has been assigned
        if (scoreSlider == null)
        {
            // If not, find the Slider component in the scene and assign it
            scoreSlider = FindObjectOfType<Slider>();
            if (scoreSlider != null)
            {
                scoreSlider.maxValue = 10;
                scoreSlider.value = 0;
                Debug.Log("Slider found and initialized.");
            }
            else
            {
                Debug.LogError("No Slider found in the scene for DestroyableGameObject.");
            }
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!destroyed)
        {
            if (timer >= destroyTime)
            {
                DestroyObject(false);
            }
        }
    }

    void OnDestroy()
    {
        if (!destroyed)
        {
            AddPoints();
        }
    }

    void DestroyObject(bool grantPoints)
    {
        destroyed = true;

        if (!grantPoints)
        {
            SubtractPoints();
        }

        Destroy(gameObject);
    }

    void AddPoints()
    {
        if (scoreSlider != null)
        {
            scoreSlider.value += pointValue;
            Debug.Log("Points added. Current score: " + scoreSlider.value);
        }
    }

    void SubtractPoints()
    {
        if (scoreSlider != null)
        {
            scoreSlider.value -= pointValue;
            Debug.Log("Points subtracted. Current score: " + scoreSlider.value);
        }
    }
}
