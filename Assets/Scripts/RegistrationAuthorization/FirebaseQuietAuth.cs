using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;

public class FirebaseQuietAuth : MonoBehaviour
{
    FirebaseAuth auth;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;

        string savedUserPassword = PlayerPrefs.GetString("Password");
        string savedUserEmail = PlayerPrefs.GetString("Email");
        auth.SignInWithEmailAndPasswordAsync(savedUserEmail, savedUserPassword).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);

        });
    }
}
