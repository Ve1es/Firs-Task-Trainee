using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public StartGame startGame;

    private void Start()
    {
        startGame.startGameEvent += GetControl;
    }

    void GetControl()
    {
        if (IsMobilePlatformWithRemote())
        {
            playerController.SetControlStrategy(new MobileControlStrategy());
        }
        else
        {
            playerController.SetControlStrategy(new DesktopControlStrategy());
        }
    }

    bool IsMobilePlatformWithRemote()
    {
        bool isMobileWithRemote = false;

#if UNITY_EDITOR
        if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.Android ||
            EditorUserBuildSettings.activeBuildTarget == BuildTarget.iOS)
        {
            isMobileWithRemote = true;
        }
#else
    if (Application.isMobilePlatform)
    {
        return isMobileWithRemote = true;
    }
#endif

        // Дополнительная проверка на Unity Remote
      /*  
        if(!UnityEditor.EditorApplication.isRemoteConnected)
        {
            isMobileWithRemote = false;
        }*/

        return isMobileWithRemote;
    }
}
