using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class DataCheckAuthorization : MonoBehaviour
{
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;

    public Registration register;

    public Canvas errorCanvas;
    public TextMeshProUGUI scoreText;

    private string _errors;

    public void CheckData()
    {
        _errors = string.Empty;
        if (_password.text.Length < 8)
        {
            _errors += "Короткий пароль";
        }
        if (!IsValidEmail(_email.text))
        {
            _errors += "Некоректный email";
        }
        if (_errors != null&&_errors!="")
        {
            ErrorsOutput();
        }
        else
        {
            register.SignIn();
        }
    }
    private void ErrorsOutput()
    {
        errorCanvas.gameObject.SetActive(true);
        scoreText.SetText("");
        scoreText.text = _errors.ToString();
    }

    public static bool IsValidEmail(string email)
    {
        string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        Match match = Regex.Match(email, pattern);
        return match.Success;
    }
}
