using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GaugeManager : MonoBehaviour
{
    public int coinCount = 0; // ���� ���� ��
    public Slider coinProgressBar; // �����̴� UI
    public int maxCoins = 100; // �ִ� ���� �� (���� ���� ����)
    public PlayerManager playerManager;

    void Start()
    {
        // �ʱ� �����̴� ���� ����
        if (coinProgressBar != null)
        {
            coinProgressBar.maxValue = maxCoins;
            coinProgressBar.value = coinCount;
        }
    }

    // ���� ȹ�� �� ȣ��Ǵ� �Լ�
    public void AddCoin()
    {
        coinCount++;

        // �����̴� ������Ʈ
        if (coinProgressBar != null)
        {
            coinProgressBar.value = coinCount;
        }

        // ���� 100�� ȹ�� �� ���� ����
        if (coinCount >= maxCoins)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // ���� ���� ó��
        Debug.Log("100 Coins Collected! Game Over!");
    }
}
