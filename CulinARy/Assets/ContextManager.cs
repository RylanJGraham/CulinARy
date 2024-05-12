using UnityEngine;
using System.Collections;

public class ContextManager : MonoBehaviour
{
    public GameObject[] contexts; // Array to hold the GameObjects representing different contexts
    private int activeContextIndex = -1; // Index of the currently active context, initially set to -1

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

            // Delay switching to the next context after 5 seconds
            StartCoroutine(DelayedContextSwitch(5f));
        }
    }

    // Coroutine to delay switching to the next context after a specified time
    private IEnumerator DelayedContextSwitch(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Switch to the next context if available
        if (activeContextIndex + 1 < contexts.Length)
        {
            SwitchContext(activeContextIndex + 1);
        }
    }

    // Activate the context at the specified index and deactivate others
    public void SwitchContext(int index)
    {
        // Check if the index is valid and different from the currently active context
        if (index >= 0 && index < contexts.Length && index != activeContextIndex)
        {
            // Deactivate the currently active context
            if (activeContextIndex >= 0 && activeContextIndex < contexts.Length)
            {
                contexts[activeContextIndex].SetActive(false);
            }

            // Activate the context at the specified index
            contexts[index].SetActive(true);
            activeContextIndex = index;
        }
    }
}
