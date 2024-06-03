using UnityEngine;
using UnityEngine.UI;

public class InfoTabManager : MonoBehaviour
{
    [System.Serializable]
    public class Tab
    {
        public Button tabButton;   // Button for the tab
        public GameObject content; // Content associated with the tab
    }

    public Tab[] tabs;

    void Start()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            int index = i;
            tabs[i].tabButton.onClick.AddListener(() => ShowTab(index));
        }

        // Initialize by showing the first tab
        ShowTab(0);
    }

    public void ShowTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            bool isActive = i == index;
            tabs[i].content.SetActive(isActive);
        }
    }
}
