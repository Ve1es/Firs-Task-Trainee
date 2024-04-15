using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoresDisplay : MonoBehaviour
{
    public GameObject playerContainerPrefab;
    public Transform contentParent;

    public void DisplayPlayerScores(string[,] playerScores)
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < playerScores.GetLength(0); i++)
        {
            string playerName = playerScores[i, 0];
            string playerScore = playerScores[i, 1];

            GameObject playerContainer = Instantiate(playerContainerPrefab, contentParent);

            TMP_Text nameText = playerContainer.transform.Find("Name").GetComponent<TMP_Text>();
            TMP_Text scoreText = playerContainer.transform.Find("Score").GetComponent<TMP_Text>();

            nameText.text = playerName;
            scoreText.text = playerScore;
        }
    }
}
