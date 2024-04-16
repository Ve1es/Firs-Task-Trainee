using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGameAfterAD : MonoBehaviour
{
    public GameObject player;
    public Player playerLogic;
    public CloseCanvas canvas;
    public RewardAD rewardAD;

    public void Start()
    {
        rewardAD.endAD += Respawn;
    }
    public void Respawn()
    {
        ClearObstaclesAroundPlayer();
        StartCoroutine(WaitCleaning());
        canvas.Close();
    }

    private void ClearObstaclesAroundPlayer()
    {
        GameObject obstacleCleaner = player.transform.Find("ObstacleRespawnClear").gameObject;
        StartCoroutine(EnableObjectForHalfSecond(obstacleCleaner));
    }
    IEnumerator EnableObjectForHalfSecond(GameObject obstacleCleaner)
    {
        // �������� ������
        obstacleCleaner.SetActive(true);

        // ���� ��� �������
        yield return new WaitForSeconds(0.5f);

        // ��������� ������
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
