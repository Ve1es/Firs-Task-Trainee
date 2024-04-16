using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    private const string _playerPrefsPasswordFieldName = "Password";
    private const string _playerPrefsEmailFieldName = "Email";
    public void Exit()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        GoMenuMethod();
        PlayerPrefs.DeleteKey(_playerPrefsEmailFieldName);
        PlayerPrefs.DeleteKey(_playerPrefsPasswordFieldName);
        Debug.Log("Logged out from Firebase");
    }
    public void GoMenuMethod()
    {
        SceneManager.LoadScene(0);
    }
}
