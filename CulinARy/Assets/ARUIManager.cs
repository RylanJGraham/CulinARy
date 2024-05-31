using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARUIManager : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    public GameObject popupWindow;
    public GameObject detailedMessage;
    public Button moreInfoButton;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnObserverStatusChanged;
        }

        popupWindow.SetActive(false);
        detailedMessage.SetActive(false);
        moreInfoButton.gameObject.SetActive(false); // Ensure the button is hidden at start
    }

    private void OnObserverStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        Debug.Log("Target Status Changed: " + status.Status);
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            OnTargetFound();
        }
        else
        {
            OnTargetLost();
        }
    }

    private void OnTargetFound()
    {
        Debug.Log("Target Found");
        popupWindow.SetActive(true);
        moreInfoButton.gameObject.SetActive(true);
    }

    private void OnTargetLost()
    {
        Debug.Log("Target Lost");
        popupWindow.SetActive(false);
        detailedMessage.SetActive(false);
        moreInfoButton.gameObject.SetActive(false);
    }

    public void ShowDetailedMessage()
    {
        Debug.Log("Show Detailed Message");
        detailedMessage.SetActive(true);
    }

    public void CloseDetailedMessage()
    {
        Debug.Log("Close Detailed Message");
        detailedMessage.SetActive(false);
    }

    public void CloseMoreInfoButton()
    {
        Debug.Log("Close More Info Button");
        moreInfoButton.gameObject.SetActive(false);
    }
}

