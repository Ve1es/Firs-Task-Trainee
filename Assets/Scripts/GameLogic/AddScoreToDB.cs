using Firebase.Auth;
using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreToDB : MonoBehaviour
{
    public Score score;
    private int _finalScore;

    public void WriteScore()
    {
        _finalScore = score.GetScore();
        var auth = FirebaseAuth.DefaultInstance;
        string userId;
        DatabaseReference databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        if (auth.CurrentUser != null)
        {
            // ѕолучаем UID текущего пользовател€
            userId = auth.CurrentUser.UserId;
            string path = "users/" + userId;
            var userData = new Dictionary<string, object>
        {
            { "score", _finalScore.ToString()}
        };

            // «аписываем данные пользовател€ в базу данных
            //databaseReference.Child("users").Child(userId).SetValueAsync(userData);
            databaseReference.Child(path).UpdateChildrenAsync(userData).ContinueWith(task =>
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
}
