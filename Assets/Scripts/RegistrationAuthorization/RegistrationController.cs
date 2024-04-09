using Firebase.Auth;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class RegistrationController : MonoBehaviour
{
    [SerializeField] private TMP_InputField Name;
    [SerializeField] private TMP_InputField Email;
    [SerializeField] private TMP_InputField Password;
    [SerializeField] private TMP_InputField ConfrimedPassword;

    private const int _startRecord = 0;
    public void Registration()
    {

        if(CheckData())
        {
            DatabaseManager.CreateUser(Name.text, Email.text, Password.text, _startRecord);
        }

    }
    bool CheckData()
    {
        bool check = true;
        if (!CheckRegistrationData.IsValidEmail(Email.text))
        {
            Debug.Log("wrong email");
            check = false; }

        if (!CheckRegistrationData.PasswordCheck(Password.text, ConfrimedPassword.text))
        { 
            Debug.Log("wrong password"); 
            check = false;
        }
        return check;
    }
}
