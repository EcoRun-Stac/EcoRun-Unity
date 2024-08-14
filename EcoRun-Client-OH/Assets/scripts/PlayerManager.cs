using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI ���ӽ����̽� �߰�

public class PlayerManager : MonoBehaviour
{
    public float jumpHeight = 2f; // ���� ����
    public float jumpDuration = 0.5f; // ���� �ð�
    public float slideDuration = 1f; // �����̵� �ð�

    public Sprite jumpSprite; // ������ �� ����� ��������Ʈ
    public Sprite slideSprite; // �����̵��� �� ����� ��������Ʈ
    public Sprite defaultSprite; // �⺻ ��������Ʈ

    private Vector3 startPosition;
    private bool isJumping = false;
    private bool isSliding = false;
    private float jumpTimer;
    private SpriteRenderer spriteRenderer;

    // ScoreManager�� Ư�� ���ӽ����̽��� ���
    public ScoreManager scoreScript; // ������ �����ϴ� ��ũ��Ʈ (�����Ϳ��� �Ҵ�)
    public Button jumpButton; // Jump ��ư
    public Button slideButton; // Slide ��ư

    private Coroutine resetSpriteCoroutine;

    public HeartManager heartManager;
    public int heartIndex = 0;

    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText;
    public GameObject[] stars;
    public int score = 0;
    public int gauge = 0;

    public Sprite BigEmptyStar;
    public Sprite SmallEmptyStar;

    public GameObject focusObject; // Focus ������Ʈ�� �����Ϳ��� �Ҵ�
    private Vector3 focusOriginalPosition;

    void Start()
    {
        gameOverUI.SetActive(false);
        startPosition = transform.position; // ���� ��ġ ����
        focusOriginalPosition = focusObject.transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ�� ������
        defaultSprite = spriteRenderer.sprite; // �⺻ ��������Ʈ ����

        // �����Ϳ��� scoreManager�� �Ҵ�Ǿ����� Ȯ��
        if (scoreScript == null)
        {
            Debug.LogError("ScoreManager�� �Ҵ���� �ʾҽ��ϴ�. �����Ϳ��� ScoreManager�� PlayerManager�� �Ҵ��ϼ���.");
        }

        // ��ư�� �̺�Ʈ �߰�
        jumpButton.onClick.AddListener(Jump);
        slideButton.onClick.AddListener(Slide);
    }

    void Update()
    {
        // ���� �� �����̵� ���� �״�� ����
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;
            float t = jumpTimer / jumpDuration;

            if (t < 0.5f)
            {
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * jumpHeight, t * 2);
                focusObject.transform.position = Vector3.Lerp(focusOriginalPosition, focusOriginalPosition + Vector3.up * jumpHeight, t*2);
            }
            else
            {
                transform.position = Vector3.Lerp(startPosition + Vector3.up * jumpHeight, startPosition, (t - 0.5f) * 2);
                focusObject.transform.position = Vector3.Lerp(focusOriginalPosition + Vector3.up * jumpHeight, focusOriginalPosition, (t - 0.5f) * 2);
            }

            if (jumpTimer >= jumpDuration)
            {
                transform.position = startPosition;
                isJumping = false;
                jumpTimer = 0f; // Ÿ�̸� �ʱ�ȭ
                spriteRenderer.sprite = defaultSprite; // �⺻ ��������Ʈ�� �ǵ�����
            }
        }
    }

    IEnumerator ResetSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.sprite = defaultSprite;
        isSliding = false; // �����̵� ���� ����
    }

    public void Jump()
    {
        isJumping = true;
        jumpTimer = 0f; // ���� ���� �� Ÿ�̸� �ʱ�ȭ
        spriteRenderer.sprite = jumpSprite; // ���� ��������Ʈ�� ����
    }

    public void Slide()
    {
        Debug.Log("sliding");
        isSliding = true;
        spriteRenderer.sprite = slideSprite; // �����̵� ��������Ʈ�� ����

        // �����̵尡 ������ �⺻ ��������Ʈ�� �ǵ����� Coroutine ����
        if (resetSpriteCoroutine != null)
        {
            StopCoroutine(resetSpriteCoroutine);
        }
        resetSpriteCoroutine = StartCoroutine(ResetSpriteAfterDelay(slideDuration));
    }
    
    public void GameStart()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GamePause()
    {
        gameOverUI.SetActive(true);
        scoreText.text = GaugeManager.scoreCount + "m";

        Debug.Log("endGame start");
        if (heartIndex > 1)
        {
            SpriteRenderer sr = stars[0].GetComponent<SpriteRenderer>();
            sr.sprite = BigEmptyStar;
        }
        if (score < 100)
        {
            SpriteRenderer sr = stars[1].GetComponent<SpriteRenderer>();
            sr.sprite = SmallEmptyStar;
        }
        if(GaugeManager.scoreCount < 100)
        {
            SpriteRenderer sr = stars[2].GetComponent<SpriteRenderer>();
            sr.sprite = SmallEmptyStar;
        }

        Time.timeScale = 0f; // ���� �Ͻ�����
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            if (scoreScript != null)
            {
                scoreScript.IncreaseItem(); // ���� ����
                score++;
            }
            else
            {
                Debug.LogError("ScoreManager is null when trying to increase score.");
            }
            Destroy(other.gameObject); // ���� ����
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("Attack"))
        {
            if (scoreScript != null)
            {
                scoreScript.DecreaseHeart();
                heartIndex++;
            }
            
            if(heartIndex > 4)
            {
                SceneManager.LoadScene("GameOver");
                Debug.Log("heartIndex gameover");
            }
            Destroy(other.gameObject);
        }

        if(GaugeManager.scoreCount == 100)
        {
            GamePause();
        }
    }
}
