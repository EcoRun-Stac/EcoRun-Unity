using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    public int heartCount = 0;
    public HeartManager heartManager;

    void Start()
    {
        score = 0;
        UpdateScore(); // �ʱ� ���� ����
    }

    public void IncreaseScore()
    {
        score += 1;
        UpdateScore();
    }

    public void DecreaseHeart()
    {
        heartManager.DestroyHeart(heartCount);
        heartCount++;
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = string.Format("X {0:D3}", score);
        }
        else
        {
            Debug.LogError("ScoreText�� null�Դϴ�. UI�� Ȯ���ϼ���.");
        }
    }
}
