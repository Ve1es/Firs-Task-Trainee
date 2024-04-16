using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoresDisplay : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    private const int _firstRow = 0;
    private const int _secondRow=1;


  

    public void DisplayPlayerScores(string[,] playerScores)
    {
        for (int i = 0; i < playerScores.GetLength(0); i++)
        {
            GameObject newRow = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] textFields = newRow.GetComponentsInChildren<TextMeshProUGUI>();
            textFields[0].text = playerScores[i, _firstRow];
            textFields[1].text = playerScores[i, _secondRow];

        }
    }
}
