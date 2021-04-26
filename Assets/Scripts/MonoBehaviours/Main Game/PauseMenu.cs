//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using MonoBehaviours.Questions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours.Main_Game
{
    public class PauseMenu : MonoBehaviour
    {
        public static bool gameIsPaused;

        public GameObject pauseMenuUI;

        private bool _lockCursorAfterResume = true;
        private float _timeScaleBeforePause = 1f;

        private void Update()
        {
            //check for escape input
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
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
            //hide ui
            pauseMenuUI.SetActive(false);
            
            //restore time scale
            Time.timeScale = _timeScaleBeforePause;
            
            //restore cursor lock mode
            if (_lockCursorAfterResume)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            
            //unpause the game
            gameIsPaused = false;
        }

        //called when click on back to menu button
        public void BackToMenu()
        {
            //restore time scale
            Time.timeScale = 1f;
            
            //disable question panel if enabled
            if (QuestionGenerator.Instance.IsQuestionPanelEnabled)
            {
                QuestionGenerator.Instance.DisableQuestionPanel();
            }
            
            //load scene
            SceneManager.LoadScene("Menu");
        }

        private void Pause()
        {
            //open ui
            pauseMenuUI.SetActive(true);
            
            //backup time scale
            _timeScaleBeforePause = Time.timeScale;
            
            //set time scale
            Time.timeScale = 0f;
            
            //backup cursor lock state
            _lockCursorAfterResume = Cursor.lockState == CursorLockMode.Locked;
            
            //set cursor lock state
            Cursor.lockState = CursorLockMode.None;
            
            //pause the game
            gameIsPaused = true;
        }
    }
}