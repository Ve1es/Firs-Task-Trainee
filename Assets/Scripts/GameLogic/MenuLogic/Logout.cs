using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logout : MonoBehaviour
{
    public void Exit()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        GoMenuMethod();
        PlayerPrefs.DeleteKey("Email");
        PlayerPrefs.DeleteKey("Password");
        Debug.Log("Logged out from Firebase");
    }
    public void GoMenuMethod()
    {
        SceneManager.LoadScene(0);
    }
}
