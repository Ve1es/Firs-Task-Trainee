using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public GameObject gO;
    public void Close()
    {
        gO.SetActive(false);
    }
}
