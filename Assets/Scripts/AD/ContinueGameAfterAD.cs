using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameAfterAD : MonoBehaviour
{
    public GameObject player;
    public Player playerLogic;
    public void Respawn()
    {
        ClearObstaclesAroundPlayer();
        StartCoroutine(WaitCleaning());
    }

    private void ClearObstaclesAroundPlayer()
    {
        GameObject obstacleCleaner = player.transform.Find("ObstacleRespawnClear").gameObject;
        StartCoroutine(EnableObjectForHalfSecond(obstacleCleaner));
    }
    IEnumerator EnableObjectForHalfSecond(GameObject obstacleCleaner)
    {
        // Включаем объект
        obstacleCleaner.SetActive(true);

        // Ждем пол секунды
        yield return new WaitForSeconds(0.5f);

        // Выключаем объект
        obstacleCleaner.SetActive(false);
    }
    private IEnumerator WaitCleaning()
    {
        yield return new WaitForSeconds(0.1f);

        ChangeState();
        ChangeUI();
        Unpause();
    }
    private void ChangeState()
    {
        playerLogic.Run();
    }
    private void ChangeUI()
    {
        playerLogic.endGameCanvas.SetActive(false);
        playerLogic.inGameCanvas.SetActive(true);
    }
    private void Unpause()
    {
        Time.timeScale = 1f;
    }
}
