using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button myButton;       // ��ư ������Ʈ
    public Sprite stopSprite;
    public Sprite playSprite;
    private Image buttonImage;    // ��ư�� �̹��� ������Ʈ
    public PlayerManager playerManager;

    private bool isPaused = false;

    void Start()
    {
        buttonImage = myButton.GetComponent<Image>();

        // ��ư Ŭ�� �̺�Ʈ�� �޼��� ���
        myButton.onClick.AddListener(TogglePause);

    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();

        }
    }

    public void PauseGame()
    {
        buttonImage.sprite = playSprite;
        FindObjectOfType<PlayerManager>().GamePause();
        Time.timeScale = 0f; // ���� �Ͻ�����

    }

    public void ResumeGame()
    {
        buttonImage.sprite = stopSprite;
        FindObjectOfType<PlayerManager>().GameStart();
        Time.timeScale = 1f; // ���� �簳

    }
}

