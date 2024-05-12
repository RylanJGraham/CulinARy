using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;
    public float duration = 3f;

    private float timer = 0f;

    void Start()
    {
        // Reset the slider value to zero at the start
        slider.value = 0f;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Calculate the progress (value) based on the timer and duration
        float progress = Mathf.Clamp01(timer / duration);

        // Update the slider value with the progress
        slider.value = progress;

        // If the progress reaches 100%, stop updating the slider
        if (progress >= 1f)
        {
            enabled = false; // Disable this script
        }
    }
}
