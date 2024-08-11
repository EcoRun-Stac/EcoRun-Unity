using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private int score = 0; // ���� ����
    public int total = 100;
    public int coin;

    void Start()
    {
        StartCoroutine(UpdateScoreText());
        coin = 0;
    }

    void UpdateScore()
    {
        score++;
        scoreText.text = string.Format("X {0:D3}", score);
    }

    public void IncreaseScore()
    {
        coin++;
        if (coin >= total)
        {
            Debug.Log("Finish");
        }
    }

    public void DecreaseScore()
    {
        coin--;
    }

    IEnumerator UpdateScoreText()
    {
        while (true) // ���� ����, �ʿ信 ���� ���� ������ �߰��� �� �ֽ��ϴ�.
        {
            // ���⿡ 1�ʸ��� ������ �۾��� �߰��ϼ���.
            // Debug.Log("1�ʸ��� ����Ǵ� �۾�");
            UpdateScore();
            // 1�� ���� ���
            yield return new WaitForSeconds(1f);
        }
    }
}
