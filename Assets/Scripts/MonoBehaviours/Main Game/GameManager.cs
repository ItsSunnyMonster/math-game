//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using System.Collections;
using System.Collections.Generic;
using MonoBehaviours.Playfab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MonoBehaviours.Main_Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public static int worldHighScoreBefore = 0;
        public static int personalHighScoreBefore = 0;
        public static int timeThisRound;

        private bool _receivedPlayerItem = false;
        private bool _receivedLeaderboard = false;
        private bool _sentLeaderboard = false;

        private void Awake()
        {
            //check for duplicates and set singleton
            if (Instance != null)
            {
                Destroy(Instance.gameObject);
            }

            Instance = this;
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

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public IEnumerator GameOver()
        {
            yield return null;
            Cursor.lockState = CursorLockMode.None;

            PlayfabManager.Instance.GetPlayerLeaderBoardItem(ReceiveItem);

            PlayfabManager.Instance.GetLeaderBoard(ReceiveLeaderboard);

            timeThisRound = Timer.Instance.time;
            PlayfabManager.Instance.SendNewValueToLeaderBoard(timeThisRound, LeaderboardSent);
        }

        private void ReceiveItem(GetLeaderboardAroundPlayerResult result)
        {
            if (result.Leaderboard.Count > 0)
            {
                personalHighScoreBefore = result.Leaderboard[0].StatValue;
            }

            _receivedPlayerItem = true;
            if (_receivedPlayerItem && _receivedLeaderboard && _sentLeaderboard)
            {
                LoadScene();
            }
        }

        private void ReceiveLeaderboard(GetLeaderboardResult result)
        {
            if (result.Leaderboard.Count > 0)
            {
                worldHighScoreBefore = result.Leaderboard[0].StatValue;
            }

            _receivedLeaderboard = true;
            if (_receivedPlayerItem && _receivedLeaderboard && _sentLeaderboard)
            {
                LoadScene();
            }
        }

        private void LeaderboardSent(UpdatePlayerStatisticsResult result)
        {
            _sentLeaderboard = true;
            if (_receivedPlayerItem && _receivedLeaderboard && _sentLeaderboard)
            {
                LoadScene();
            }
        }

        private void LoadScene()
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}