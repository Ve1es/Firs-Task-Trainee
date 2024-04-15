using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloseCanvas : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
