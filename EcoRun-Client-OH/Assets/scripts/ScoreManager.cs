using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    private int score = 0; // 현재 점수
    public int total = 100;
    public int coin = 0;
    public HeartManager heartManager;
    public int HeartCount = 0;

    void Start()
    {
        coin = 0;
    }

    void UpdateScore()
    {
        // Debug.Log(coin);
        scoreText.text = string.Format("X {0:D3}", coin);
    }

    public void IncreaseScore()
    {
        coin++;
        if (coin >= total)
        {
            Debug.Log("Finish");
        }
        UpdateScore();
    }

    // public void DecreaseScore()
    // {
    //     if(HeartCount < 5)
    //     {
    //         heartManager.DestroyHeart(HeartCount);
    //         HeartCount++;
    //     }
    //     else
    //     {
    //         SceneManager.LoadScene("GameOver");
    //     }
    // }

    // IEnumerator UpdateScoreText()
    // {
    //     while (true) // 무한 루프, 필요에 따라 종료 조건을 추가할 수 있습니다.
    //     {
            // 여기에 1초마다 실행할 작업을 추가하세요.
            //  Debug.Log("1초마다 실행되는 작업");
    //         UpdateScore();
            // 1초 동안 대기
    //         yield return new WaitForSeconds(1f);
    //     }
    // }
}
