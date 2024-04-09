using Firebase.Database;
using System;
using System.Collections;
using Firebase;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private static string _userID;
    private static DatabaseReference _databaseReference;

    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    void Start()
    {
        _userID = RandomUserID();
        //_userID = SystemInfo.deviceUniqueIdentifier;
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    string RandomUserID()
    {
        // Создаем новый объект Random
        System.Random rand = new System.Random();

        // Генерируем случайную строку длиной в 10 символов
        string randomString = "";
        for (int i = 0; i < 10; i++)
        {
            randomString += chars[rand.Next(chars.Length)];
        }

        return randomString;
    }
    public static void CreateUser(string name, string email, string password, int startRecord)
    {
        User NewUser = new User(name, email, password, startRecord);
        string Json = JsonUtility.ToJson(NewUser);

        _databaseReference.Child("users").Child(_userID).SetRawJsonValueAsync(Json);
    }

    public IEnumerator GetData(Action<string> onCallback, string fieldName)
    {
        var UserData = _databaseReference.Child("users").Child(_userID).Child(fieldName).GetValueAsync();
        yield return new WaitUntil(predicate: () => UserData.IsCompleted);

        if(UserData!=null)
        {
            DataSnapshot Snapshot = UserData.Result;

            onCallback.Invoke((string)Snapshot.Value);
        }
    }

    public string GetInfo(string fieldName) {
        string nameData="";
        StartCoroutine(GetData((string name) =>
        {
            nameData = name;
        }, fieldName));
        return nameData;
    }
}
