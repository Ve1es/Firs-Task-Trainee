using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvas : MonoBehaviour
{
    public GameObject canvas;
    
    public void Open()
    {
        canvas.SetActive(true);
    }
}
