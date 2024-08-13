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
    public static int scoreCount = 0; // ���� ���� ��
    public Slider coinProgressBar; // �����̴� UI
    public int maxCoins = 350; // �ִ� ���� �� (���� ���� ����)
    public PlayerManager playerManager;

    void Start()
    {
        // �ʱ� �����̴� ���� ����
        if (coinProgressBar != null)
        {
            coinProgressBar.maxValue = maxCoins;
            coinProgressBar.value = scoreCount;
        }
        StartCoroutine(AddCoinEverySecond());
    }

    IEnumerator AddCoinEverySecond()
    {
        while (true) // ���� ����, ������ ����� ������ ����˴ϴ�.
        {
            AddScore(); // 1�ʸ��� AddCoin() �Լ� ȣ��
            yield return new WaitForSeconds(1f); // 1�� ���
        }
    }

    // ���� ȹ�� �� ȣ��Ǵ� �Լ�
    public void AddScore()
    {
        scoreCount++;

        // �����̴� ������Ʈ
        if (coinProgressBar != null)
        {
            coinProgressBar.value = scoreCount;
            UpdateScore();
        }

        // ���� 100�� ȹ�� �� ���� ����
        if (scoreCount >= maxCoins)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // ���� ���� ó��
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
            Debug.LogError("ScoreText�� null�Դϴ�. UI�� Ȯ���ϼ���.");
        }
    }
}
