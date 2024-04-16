using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteScoreInDB : MonoBehaviour
{
    public Score score;
    private int _finalScore;
    private const string _dataNameScore = "score";
    private const string _dataNameUsers = "users";
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
            { _dataNameScore, _finalScore.ToString()}
        };

            // «аписываем данные пользовател€ в базу данных
            databaseReference.Child(_dataNameUsers).Child(userId).SetValueAsync(userData);
        }
        else
        {
            Debug.LogError("User is not authenticated.");
        }

    }
}
