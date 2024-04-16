using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AddScoreToDB : MonoBehaviour
{
    DatabaseReference databaseReference;
    public Score score;
    private int _finalScore;
    int _nowScoreValue = 0;

    void Start()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

    }
    public async void WriteScore()
    {
        var auth = FirebaseAuth.DefaultInstance;
        _finalScore = score.GetScore();
        string userId;
       

        if (auth.CurrentUser != null)
        {

            // Получаем UID текущего пользователя
            userId = auth.CurrentUser.UserId;

            int oldScore = int.Parse(await GetScoreAsync(userId));
            string path = "users/" + userId;
            var userData = new Dictionary<string, object>
        {
            { "score", _finalScore.ToString()}
        };
            if (_finalScore > oldScore)
                databaseReference.Child(path).UpdateChildrenAsync(userData).ContinueWithOnMainThread(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed to update data: " + task.Exception);
                    }
                    else if (task.IsCompleted)
                    {
                        Debug.Log("Data updated successfully!");
                    }
                });
        }
        else
        {
            Debug.LogError("User is not authenticated.");
        }

    }
    string GetScore(string userId)
    {
        string scoreValue = "0";
        // Получение значения поля score из базы данных для пользователя с заданным ID
        databaseReference.Child("users").Child(userId).Child("score").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Ошибка при получении данных score пользователя: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Получение значения поля score
                scoreValue = snapshot.GetValue(true).ToString();
            }
        });
        return scoreValue;
    }

    private async Task<string> GetScoreAsync(string userId)
    {
        string scoreValue = "0";

        // Получение значения поля score из базы данных для пользователя с заданным ID
        await databaseReference.Child("users").Child(userId).Child("score").GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Ошибка при получении данных score пользователя: " + task.Exception);
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                // Получение значения поля score
                scoreValue = snapshot.GetValue(true).ToString();
            }
        });

        return scoreValue;
    }
}
