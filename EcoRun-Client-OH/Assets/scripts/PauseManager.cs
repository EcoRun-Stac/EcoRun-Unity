using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // 일시정지 메뉴 UI를 연결

    private bool isPaused = true;

    void Start()
    {
        TogglePause();
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
        pauseMenuUI.SetActive(true); // 일시정지 메뉴 표시
        Time.timeScale = 0f; // 게임 일시정지
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // 일시정지 메뉴 숨기기
        Time.timeScale = 1f; // 게임 재개
    }
}

