using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaugeManager : MonoBehaviour
{
    public int coinCount = 0; // 현재 코인 수
    public Slider coinProgressBar; // 슬라이더 UI
    public int maxCoins = 100; // 최대 코인 수 (게임 종료 기준)
    public PlayerManager playerManager;

    void Start()
    {
        // 초기 슬라이더 값을 설정
        if (coinProgressBar != null)
        {
            coinProgressBar.maxValue = maxCoins;
            coinProgressBar.value = coinCount;
        }
    }

    // 코인 획득 시 호출되는 함수
    public void AddCoin()
    {
        coinCount++;

        // 슬라이더 업데이트
        if (coinProgressBar != null)
        {
            coinProgressBar.value = coinCount;
        }

        // 코인 100개 획득 시 게임 종료
        if (coinCount >= maxCoins)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // 게임 종료 처리
        Debug.Log("100 Coins Collected! Game Over!");
    }
}
