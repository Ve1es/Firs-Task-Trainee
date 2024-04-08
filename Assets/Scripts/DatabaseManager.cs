using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    private string _userID;
    private DatabaseReference _databaseReference;

    private string _userName;
    private string _userPassword;
    private string _userEmail;
    private string _userMaxScore;
    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    private void CreateUser(string name, string email, string password)
    {
        User NewUser = new User(name, email, password);
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
