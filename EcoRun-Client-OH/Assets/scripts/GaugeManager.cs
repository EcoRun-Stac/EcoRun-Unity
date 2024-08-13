using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Xml.Serialization;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class GaugeManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreCount = 0; // 현재 코인 수
    public Slider coinProgressBar; // 슬라이더 UI
    public int maxCoins = 350; // 최대 코인 수 (게임 종료 기준)
    public PlayerManager playerManager;

    void Start()
    {
        // 초기 슬라이더 값을 설정
        if (coinProgressBar != null)
        {
            coinProgressBar.maxValue = maxCoins;
            coinProgressBar.value = scoreCount;
        }
        StartCoroutine(AddCoinEverySecond());
    }

    IEnumerator AddCoinEverySecond()
    {
        while (true) // 무한 루프, 게임이 종료될 때까지 실행됩니다.
        {
            AddScore(); // 1초마다 AddCoin() 함수 호출
            yield return new WaitForSeconds(1f); // 1초 대기
        }
    }

    // 코인 획득 시 호출되는 함수
    public void AddScore()
    {
        scoreCount++;

        // 슬라이더 업데이트
        if (coinProgressBar != null)
        {
            coinProgressBar.value = scoreCount;
            UpdateScore();
        }

        // 코인 100개 획득 시 게임 종료
        if (scoreCount >= maxCoins)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // 게임 종료 처리
        Debug.Log("100 Coins Collected! Game Over!");
    }

    void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = string.Format("X {0:D3}", scoreCount);
        }
        else
        {
            Debug.LogError("ScoreText가 null입니다. UI를 확인하세요.");
        }
    }
}
