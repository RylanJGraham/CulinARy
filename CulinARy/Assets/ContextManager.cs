using UnityEngine;
using System.Collections;

public class ContextManager : MonoBehaviour
{
    public GameObject[] contexts; // Array to hold the GameObjects representing different contexts
    public bool verified = false; // Boolean to indicate if the user is verified

    private void Start()
    {
        // Deactivate all contexts except the first one
        for (int i = 1; i < contexts.Length; i++)
        {
            contexts[i].SetActive(false);
        }

        // Set the first context as active
        if (contexts.Length > 0)
        {
            SwitchContext(0);

            // Delay switching to the login context after 3 seconds
            StartCoroutine(DelayedContextSwitch(3f));
        }
    }

    // Coroutine to delay switching to the login context after a specified time
    private IEnumerator DelayedContextSwitch(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Switch to the login context if available
        if (contexts.Length > 1)
        {
            SwitchContext(1); // Switch to the login context
        }
    }

    // Activate the loading screen
    public void LoadingScreen()
    {
        // Deactivate all contexts except the loading context (index 3)
        for (int i = 0; i < contexts.Length; i++)
        {
            contexts[i].SetActive(i == 3); // Activate the loading context
        }
    }

    // Activate the context at the specified index and deactivate others
    public void SwitchContext(int index)
    {
        // Check if the index is valid and different from the currently active context
        if (index >= 0 && index < contexts.Length)
        {
            // Deactivate the currently active context
            for (int i = 0; i < contexts.Length; i++)
            {
                contexts[i].SetActive(i == index);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if user is verified and activate loading screen if true
        if (verified)
        {
            LoadingScreen();
        }
    }
}
