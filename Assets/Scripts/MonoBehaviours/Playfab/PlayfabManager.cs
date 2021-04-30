//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace MonoBehaviours.Playfab
{
    public class PlayfabManager : MonoBehaviour
    {
        public static PlayfabManager Instance { get; private set; }

        public delegate void LeaderboardReceivedDel(List<PlayerLeaderboardEntry> entries);

        public delegate void PlayerLeaderboardItemReceivedDel(List<PlayerLeaderboardEntry> entries);

        public delegate void LeaderboardSentDel();

        public event LeaderboardReceivedDel OnLeaderboardReceived;
        public event PlayerLeaderboardItemReceivedDel OnPlayerLeaderboardItemReceived;
        public event LeaderboardSentDel OnLeaderboardSent;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
            Login();
        }

        private void OnError(PlayFabError playFabError)
        {
            Debug.LogError("Error");
            Debug.LogError(playFabError.GenerateErrorReport());
        }

        #region Login

        private void Login()
        {
            var request = new LoginWithCustomIDRequest
            {
                CustomId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
            };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
        }

        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Login successfully! ");
        }
        
        #endregion

        #region SendNewValueToLeaderBoard

        public void SendNewValueToLeaderBoard(int value)
        {
            var request = new UpdatePlayerStatisticsRequest
            {
                Statistics = new List<StatisticUpdate>
                {
                    new StatisticUpdate
                    {
                        StatisticName = "High Score",
                        Value = value
                    }
                }
            };
            PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
        }

        private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
        {
            Debug.Log("Leaderboard update successful! ");
            OnLeaderboardSent?.Invoke();
        }
        
        #endregion

        #region GetLeaderBoard

        public void GetLeaderBoard()
        {
            var request = new GetLeaderboardRequest
            {
                StatisticName = "High Score",
                StartPosition = 0,
                MaxResultsCount = 1
            };
            PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderBoardSuccess, OnError);
        }

        private void OnGetLeaderBoardSuccess(GetLeaderboardResult result)
        {
            OnLeaderboardReceived?.Invoke(result.Leaderboard);
        }
        
        #endregion

        #region GetPlayerLeaderBoardItem

        public void GetPlayerLeaderBoardItem()
        {
            var request = new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = "High Score",
                MaxResultsCount = 1
            };
            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnGetLeaderBoardAroundPlayerSuccess, OnError);
        }

        private void OnGetLeaderBoardAroundPlayerSuccess(GetLeaderboardAroundPlayerResult result)
        {
            OnPlayerLeaderboardItemReceived?.Invoke(result.Leaderboard);
        }

        #endregion
    }
}
