using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;

public class SupabaseUserManager : MonoBehaviour
{
    public string supabaseUrl = "YOUR_SUPABASE_URL";
    public string supabaseApiKey = "YOUR_SUPABASE_API_KEY";

    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public TMP_InputField nameInputField;

    public void CreateUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;
        string name = nameInputField.text;

        StartCoroutine(RegisterUserCoroutine(email, password, name));
    }

    private IEnumerator RegisterUserCoroutine(string email, string password, string name)
    {
        // Construct the URL for the Supabase authentication endpoint
        string url = $"{supabaseUrl}/auth/v1/signup";

        // Create a JSON object with the user's email, password, and name
        string jsonRequestBody = $"{{\"email\": \"{email}\", \"password\": \"{password}\", \"name\": \"{name}\"}}";

        // Create a POST request to register the user
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(url, jsonRequestBody))
        {
            // Set request headers
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("apikey", supabaseApiKey); // Add API key to request header

            // Send the request
            yield return request.SendWebRequest();

            // Check if there was an error with the request
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Registration failed: " + request.error);
                // Handle the error (e.g., display an error message to the user)
            }
            else
            {
                Debug.Log("Registration successful!");
                // Handle successful registration (e.g., navigate to another scene)
            }
        }
    }
}
