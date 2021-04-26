//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours.Main_Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            //check for duplicates and set singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        public void Play()
        {
            //load game scene
            SceneManager.LoadScene("Game");
        }

        public void Quit()
        {
            //quit
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}