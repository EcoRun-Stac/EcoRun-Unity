using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private int score = 0; // ���� ����
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
    //     while (true) // ���� ����, �ʿ信 ���� ���� ������ �߰��� �� �ֽ��ϴ�.
    //     {
            // ���⿡ 1�ʸ��� ������ �۾��� �߰��ϼ���.
            //  Debug.Log("1�ʸ��� ����Ǵ� �۾�");
    //         UpdateScore();
            // 1�� ���� ���
    //         yield return new WaitForSeconds(1f);
    //     }
    // }
}
