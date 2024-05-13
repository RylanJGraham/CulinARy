using System; // Add this line to include the System namespace
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;

public class UserCookBook : MonoBehaviour
{
    public TMP_Text displayNameText;

    void Start()
    {
        // Get the FirebaseAuth instance
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;

        // Check if a user is currently logged in
        if (auth.CurrentUser != null)
        {
            // Access the currently logged-in user
            FirebaseUser user = auth.CurrentUser;

            // Log the user's data
            Debug.Log("User ID: " + user.UserId);
            Debug.Log("User Email: " + user.Email);
            Debug.Log("User Display Name: " + user.DisplayName);
            
            // Update display name text
            displayNameText.text = user.DisplayName + "'s";
        }
        else
        {
            // If no user is logged in, log a message
            Debug.Log("No user is currently logged in.");
        }
    }
}