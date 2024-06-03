using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnBravasButtonPressed()
    {
        PlayerPrefs.SetString("SelectedPrefab", "Bravas");
        LoadGameScene();
    }

    public void OnBurgerButtonPressed()
    {
        PlayerPrefs.SetString("SelectedPrefab", "Burger");
        LoadGameScene();
    }

    public void OnCoulantButtonPressed()
    {
        PlayerPrefs.SetString("SelectedPrefab", "Coulant");
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        // Replace "GameScene" with the name of your game scene
        SceneManager.LoadScene("Game");
    }
}
