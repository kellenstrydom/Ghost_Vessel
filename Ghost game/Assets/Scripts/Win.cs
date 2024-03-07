using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject winPanel;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Win"))
        {
            WinGame();
        }
            
    }

    void WinGame()
    {
        winPanel.SetActive(true);
    }
}
