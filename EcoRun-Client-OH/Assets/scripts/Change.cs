using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{    public void SceneChange()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("SampleScene");
        GaugeManager.scoreCount = 0;
        Time.timeScale = 1f;
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
