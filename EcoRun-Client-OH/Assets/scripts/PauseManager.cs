using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Button myButton;       // 버튼 컴포넌트
    public Sprite stopSprite;
    public Sprite playSprite;
    private Image buttonImage;    // 버튼의 이미지 컴포넌트
    public PlayerManager playerManager;

    private bool isPaused = false;

    void Start()
    {
        buttonImage = myButton.GetComponent<Image>();

        // 버튼 클릭 이벤트에 메서드 등록
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
        Time.timeScale = 0f; // 게임 일시정지

    }

    public void ResumeGame()
    {
        buttonImage.sprite = stopSprite;
        FindObjectOfType<PlayerManager>().GameStart();
        Time.timeScale = 1f; // 게임 재개

    }
}

