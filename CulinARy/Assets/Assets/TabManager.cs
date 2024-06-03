using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    [System.Serializable]
    public class Tab
    {
        public Button inactiveButton;  // Button shown when the tab is inactive
        public Button activeButton;    // Button shown when the tab is active
        public GameObject content;     // Content associated with the tab
    }

    public Tab[] tabs;

    void Start()
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            int index = i;
            tabs[i].inactiveButton.onClick.AddListener(() => ShowTab(index));
        }

        // Initialize by showing the first tab
        ShowTab(0);
    }

    public void ShowTab(int index)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            bool isActive = i == index;
            tabs[i].inactiveButton.gameObject.SetActive(!isActive);
            tabs[i].activeButton.gameObject.SetActive(isActive);
            tabs[i].content.SetActive(isActive);
        }
    }
}