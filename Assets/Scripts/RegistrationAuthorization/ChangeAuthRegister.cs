using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAuthRegister : MonoBehaviour
{
    public GameObject RegCanvas;
    public GameObject AuthCanvas;

    public void RegToAuth()
    {
        RegCanvas.SetActive(false);
        AuthCanvas.SetActive(true);
    }
    public void AuthToReg()
    {
        RegCanvas.SetActive(true);
        AuthCanvas.SetActive(false);
    }
}
