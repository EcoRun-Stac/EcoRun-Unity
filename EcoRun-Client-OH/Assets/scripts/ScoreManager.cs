using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int item;
    public int heartCount = 0;
    public HeartManager heartManager;

    void Start()
    {
        item = 0;
    }
    public void DecreaseHeart()
    {

        if (heartCount >= 0 && heartCount < 5)
        {
            heartManager.DestroyHeart(heartCount);
            heartCount++;
        }
        
    }

    public void IncreaseItem()
    {
        item++;
        scoreText.text = string.Format("X {0:D3}", item);
    }

    
}
