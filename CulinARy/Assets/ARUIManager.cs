using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ARUIManager : MonoBehaviour
{
    private ObserverBehaviour mObserverBehaviour;
    public GameObject popupWindow;
    public GameObject detailedMessage;
    public Button moreInfoButton;

    // Content Panels
    public GameObject[] contentPanels;

    // Audio Source for Background Music
    private AudioSource backgroundMusicSource;

    // Audio Source for Sound Effects
    public AudioSource soundEffectSource;
    public AudioClip buttonClickSound; // Assign the click sound effect in the Inspector

    // Pitch variation range
    public float minPitch = 0.75f;
    public float maxPitch = 1.25f;

    void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        backgroundMusicSource = GetComponent<AudioSource>();
        
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnObserverStatusChanged;
        }

        popupWindow.SetActive(false);
        detailedMessage.SetActive(false);
        moreInfoButton.gameObject.SetActive(false); // Ensure the button is hidden at start

        // Initially show the first content panel
        ShowContentPanel(0);
    }

    private void OnObserverStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        Debug.Log("Target Status Changed: " + status.Status);
        if (status.Status == Status.TRACKED)
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
        //detailedMessage.SetActive(false);           // Commenting this, the More Info PopUp window will remain opened even if the Image Target is lost.
        moreInfoButton.gameObject.SetActive(false);
    }

    public void ShowDetailedMessage()
    {
        Debug.Log("Show Detailed Message");
        detailedMessage.SetActive(true);
        
        // Show the first content panel by default when detailed message is shown
        ShowContentPanel(0);

        PlaySoundEffect();
    }

    public void CloseDetailedMessage()
    {
        Debug.Log("Close Detailed Message");
        detailedMessage.SetActive(false);

        PlaySoundEffect();
    }

    public void CloseMoreInfoButton()
    {
        Debug.Log("Close More Info Button");
        moreInfoButton.gameObject.SetActive(false);

        PlaySoundEffect();
    }

    public void ShowContentPanel(int index)
    {
        for (int i = 0; i < contentPanels.Length; i++)
        {
            contentPanels[i].SetActive(i == index);
        }

        PlaySoundEffect();
    }

    private void PlaySoundEffect()
    {
        if (soundEffectSource != null && buttonClickSound != null)
        {
            soundEffectSource.pitch = Random.Range(minPitch, maxPitch);
            soundEffectSource.PlayOneShot(buttonClickSound);
        }
    }
}

