using System; // Add this line to include the System namespace
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Auth;

public class UserDataProfile : MonoBehaviour
{
    public TMP_Text displayNameText;
    public TMP_Text signUpDateText;

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
            displayNameText.text = user.DisplayName;

            // Get and format sign-up date
            string signUpDate = GetFormattedDate(user.Metadata.CreationTimestamp);
            
            // Update sign-up date text
            signUpDateText.text = signUpDate;
        }
        else
        {
            // If no user is logged in, log a message
            Debug.Log("No user is currently logged in.");
        }
    }

    // Function to format timestamp to dd/mm/yy
    string GetFormattedDate(ulong timestamp)
    {
        try
        {
            // Convert timestamp to DateTime
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(timestamp).ToLocalTime();
            
            // Format date
            string formattedDate = dtDateTime.ToString("dd/MM/yy");
            return formattedDate;
        }
        catch (Exception e)
        {
            Debug.LogError("Error converting timestamp to DateTime: " + e.Message);
            return "N/A";
        }
    }
}