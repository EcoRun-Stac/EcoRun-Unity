using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    private int score = 0; // 현재 점수

    void Start()
    {
        StartCoroutine(UpdateScoreText());
    }

    void UpdateScore()
    {
        score++;
        scoreText.text = string.Format("X {0:D3}", score);
    }

    IEnumerator UpdateScoreText()
    {
        while (true) // 무한 루프, 필요에 따라 종료 조건을 추가할 수 있습니다.
        {
            // 여기에 1초마다 실행할 작업을 추가하세요.
            Debug.Log("1초마다 실행되는 작업");
            UpdateScore();
            // 1초 동안 대기
            yield return new WaitForSeconds(1f);
        }
    }
}
