using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuControl : MonoBehaviour
{
    public GameObject pausePanel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Shop()
    {
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    //https://discussions.unity.com/t/how-to-pause-and-resume-the-game/94643/3

    public void Stop()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
