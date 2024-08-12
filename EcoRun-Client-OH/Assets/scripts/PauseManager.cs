using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // �Ͻ����� �޴� UI�� ����

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
        pauseMenuUI.SetActive(true); // �Ͻ����� �޴� ǥ��
        Time.timeScale = 0f; // ���� �Ͻ�����
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // �Ͻ����� �޴� �����
        Time.timeScale = 1f; // ���� �簳
    }
}

