using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using Firebase.Database;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections.Generic;


public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_InputField _confrimedPassword;


   // private FirebaseAuth auth;


    public void Register()
    {
        var email = _email.text;
        var password = _password.text;
        var auth = FirebaseAuth.DefaultInstance;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }

    public void SignIn()
    {
        var email = _email.text;
        var password = _password.text;
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
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

            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);
        });
    }

    public void AddNameAndScore()
    {
        string userName = "firstUser";
        int score = 0;
        var auth = FirebaseAuth.DefaultInstance;
        string userId;
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        if (auth.CurrentUser != null)
        {
            // ѕолучаем UID текущего пользовател€
            userId = auth.CurrentUser.UserId;
            var userData = new Dictionary<string, string>
        {
            { "userName1", userName },
            { "score1", score.ToString()}
        };

            // «аписываем данные пользовател€ в базу данных
            databaseReference.Child("users").Child(userId).SetValueAsync(userData);
        }
        else
        {
            Debug.LogError("User is not authenticated.");
        }
        
    }
}
