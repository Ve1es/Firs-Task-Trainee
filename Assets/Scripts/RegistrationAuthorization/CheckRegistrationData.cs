using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CheckRegistrationData : MonoBehaviour
{
    public static bool IsValidEmail(string email)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        Match match = Regex.Match(email, pattern);
        return match.Success;
    }

    public static bool PasswordCheck(string password, string confrimPassword)
    {
        if(password == confrimPassword)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
