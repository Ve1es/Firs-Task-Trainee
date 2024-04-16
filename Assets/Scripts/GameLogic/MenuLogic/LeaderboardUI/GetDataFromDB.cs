using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor.VersionControl;
using Firebase.Extensions;
using Firebase.Auth;

public class GetDataFromDB : MonoBehaviour
{
    DatabaseReference databaseReference;
    public PlayerScoresDisplay playerScoresDisplay;

    private const string _dataNameName = "name";
    private const string _dataNameScore = "score";
    private const string _dataNameUsers = "users";

    void Start()
    {
        
    }

    private void OnEnable()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        playerScoresDisplay = GetComponent<PlayerScoresDisplay>();
        FetchPlayerData();
    }
    public void FetchPlayerData()
    {   
        databaseReference.Child(_dataNameUsers).OrderByChild(_dataNameScore).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failed to fetch player data: " + task.Exception);
                return;
            }

            DataSnapshot snapshot = task.Result;

            if (snapshot != null && snapshot.ChildrenCount > 0)
            {
                PreparingDataForDisplayMethod(snapshot);
            }
            else
            {
                Debug.Log("No player data found.");
            }
        });
    }
    
    public void PreparingDataForDisplayMethod(DataSnapshot snapshot)
    {
        List<string[]> playerDataList = new List<string[]>();

        foreach (DataSnapshot playerSnapshot in snapshot.Children)
        {
            string playerName = playerSnapshot.Child(_dataNameName).Value.ToString();
            string playerScore = playerSnapshot.Child(_dataNameScore).Value.ToString();

            string[] playerData = { playerName, playerScore };
            playerDataList.Add(playerData);
        }

        // —ортировка данных по убыванию счета
        playerDataList = playerDataList.OrderByDescending(playerData => int.Parse(playerData[1])).ToList();

        // ѕреобразование списка в двумерный массив
        string[,] playerDataArray = new string[playerDataList.Count, 2];
        for (int i = 0; i < playerDataList.Count; i++)
        {
            playerDataArray[i, 0] = playerDataList[i][0];
            playerDataArray[i, 1] = playerDataList[i][1];
        }

        playerScoresDisplay.DisplayPlayerScores(playerDataArray);
    }
   
}
