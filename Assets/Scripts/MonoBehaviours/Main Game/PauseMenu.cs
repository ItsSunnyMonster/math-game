//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private bool lockCursorAfterResume = true;
    private float timeScaleBeforePause = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = timeScaleBeforePause;
        if (lockCursorAfterResume)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        GameIsPaused = false;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        if (QuestionGenerator.instance.isQuestionPanelEnabled)
        {
            QuestionGenerator.instance.DisableQuestionPanel();
        }
        SceneManager.LoadScene("Menu");
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        timeScaleBeforePause = Time.timeScale;
        Time.timeScale = 0f;
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            lockCursorAfterResume = true;
        }
        else
        {
            lockCursorAfterResume = false;
        }
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }
}