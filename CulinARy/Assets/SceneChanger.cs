using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method to change scene based on the button clicked
    public void ChangeScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
