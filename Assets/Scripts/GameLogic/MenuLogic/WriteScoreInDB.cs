using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteScoreInDB : MonoBehaviour
{
    public Score score;
    private int _finalScore;
    void OnEnable()
    {
        _finalScore = score.GetScore();
        WriteScore();
    }

    private void WriteScore()
    {
        var auth = FirebaseAuth.DefaultInstance;
        string userId;
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        if (auth.CurrentUser != null)
        {
            // ѕолучаем UID текущего пользовател€
            userId = auth.CurrentUser.UserId;
            var userData = new Dictionary<string, string>
        {
            { "score", _finalScore.ToString()}
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
