using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Registration : MonoBehaviour
{
    private const int _startScore=0;

    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _emailRegistration;
    [SerializeField] private TMP_InputField _passwordRegistration;
    [SerializeField] private TMP_InputField _confrimedPassword;

    [SerializeField] private TMP_InputField _emailAuthorization;
    [SerializeField] private TMP_InputField _passwordAuthorization;

    public GoToGame goToGame;

    
    private event Action _endAuth;
    private event Action _endRegistration;
    private event Action _endAddData;

    private void OnEnable()
    {
        _endAuth += goToGame.GoToGameMethod;
        _endRegistration += AddNameAndScore;
        _endAddData += goToGame.GoToGameMethod;
        FirebaseQuietAuth();
    }

    public void FirebaseQuietAuth()
    {
        var auth = FirebaseAuth.DefaultInstance;

        string savedUserPassword = PlayerPrefs.GetString("Password");
        string savedUserEmail = PlayerPrefs.GetString("Email");
        if (savedUserPassword != "" && savedUserEmail != "")
        {
            auth.SignInWithEmailAndPasswordAsync(savedUserEmail, savedUserPassword).ContinueWithOnMainThread(task =>
            {
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
                _endAuth?.Invoke();
            });
        }
    }
    public void Register()
    {
        var email = _emailRegistration.text;
        var password = _passwordRegistration.text;
        var auth = FirebaseAuth.DefaultInstance;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
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
            SaveUserData(email, password);
            _endRegistration?.Invoke();
        });
    }

    public void SignIn()
    {
        var email = _emailAuthorization.text;
        var password = _passwordAuthorization.text;
        var auth = FirebaseAuth.DefaultInstance;
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
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
            SaveUserData(email, password);
            _endAuth?.Invoke();
        });
    }

    private void SaveUserData(string email, string password)
    {
        PlayerPrefs.SetString("Email", email);
        PlayerPrefs.SetString("Password", password);
        PlayerPrefs.Save();
    }
    public void AddNameAndScore()
    {
        string userName = _name.text;
        int score = _startScore;
        var auth = FirebaseAuth.DefaultInstance;
        string userId;
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        if (auth.CurrentUser != null)
        {
            // ѕолучаем UID текущего пользовател€
            userId = auth.CurrentUser.UserId;
            var userData = new Dictionary<string, string>
        {
            { "userName", userName},
            { "score", score.ToString()}
        };

            // «аписываем данные пользовател€ в базу данных
            databaseReference.Child("users").Child(userId).SetValueAsync(userData);
            _endAddData?.Invoke();
        }
        else
        {
            Debug.LogError("User is not authenticated.");
        }
        
    }
}
