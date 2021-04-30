using System;
using System.Collections.Generic;
using Classes;
using MonoBehaviours.Main_Game;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;

namespace MonoBehaviours.Playfab
{
    public class ScoreUpdater : MonoBehaviour
    {
        public TextMeshProUGUI timeText;
        public TextMeshProUGUI highScoreInfoText;

        // private int _worldHighScoreNow;
        // private int _personalHighScoreNow;
        //
        // private bool _worldHighScoreReceived = false;
        // private bool _personalHighScoreReceived = false;

        private void Awake()
        {
            // PlayfabManager.Instance.OnLeaderboardReceived += ReceiveWorldHighScore;
            // PlayfabManager.Instance.GetLeaderBoard();
            //
            // PlayfabManager.Instance.OnPlayerLeaderboardItemReceived += ReceivePersonalHighScore;
            // PlayfabManager.Instance.GetPlayerLeaderBoardItem();
        }

        private void Start()
        {
            SetupText();
            AudioManager.instance.Play("Clapping");
        }

        /*private void ReceiveWorldHighScore(List<PlayerLeaderboardEntry> entries)
        {
            if (entries.Count > 0)
            {
                _worldHighScoreNow = entries[0].StatValue;
            }

            PlayfabManager.Instance.OnLeaderboardReceived -= ReceiveWorldHighScore;
            _worldHighScoreReceived = true;
            if (_worldHighScoreReceived && _personalHighScoreReceived)
            {
                SetupText();
            }
        }

        private void ReceivePersonalHighScore(List<PlayerLeaderboardEntry> entries)
        {
            if (entries.Count > 0)
            {
                _personalHighScoreNow = entries[0].StatValue;
            }

            PlayfabManager.Instance.OnPlayerLeaderboardItemReceived -= ReceivePersonalHighScore;
            _personalHighScoreReceived = true;
            if (_worldHighScoreReceived && _personalHighScoreReceived)
            {
                SetupText();
            }
        }
        */

        private void SetupText()
        {
            timeText.text = "Your time was " +
                            HelperFunctions.TimeSpanToShortForm(TimeSpan.FromSeconds(GameManager.timeThisRound));

            highScoreInfoText.text = string.Empty;
            
            if (GameManager.worldHighScoreBefore == 0)
            {
                highScoreInfoText.text += "You are the first person to play the game. \n";
            }
            else
            {
                highScoreInfoText.text += "The world high score ";
                if (GameManager.worldHighScoreBefore > GameManager.timeThisRound)
                {
                    highScoreInfoText.text += "was ";
                }
                else
                {
                    highScoreInfoText.text += "is ";
                }
                highScoreInfoText.text +=
                    HelperFunctions.TimeSpanToShortForm(TimeSpan.FromSeconds(GameManager.worldHighScoreBefore)) + "\n";
            }

            if (GameManager.personalHighScoreBefore == 0)
            {
                highScoreInfoText.text += "This is your first time playing the game. \n";
            }
            else
            {
                highScoreInfoText.text += "Your personal high score ";
                if (GameManager.personalHighScoreBefore > GameManager.timeThisRound)
                {
                    highScoreInfoText.text += "was ";
                }
                else
                {
                    highScoreInfoText.text += "is ";
                }

                highScoreInfoText.text +=
                    HelperFunctions.TimeSpanToShortForm(TimeSpan.FromSeconds(GameManager.personalHighScoreBefore)) + "\n";
            }

            if (GameManager.worldHighScoreBefore != 0)
            {
                highScoreInfoText.text += "You ";
                if (GameManager.worldHighScoreBefore < GameManager.timeThisRound)
                {
                    highScoreInfoText.text += "were beaten by the world high score by ";
                    highScoreInfoText.text +=
                        HelperFunctions.RoundToDecimalPlaces(
                            (GameManager.timeThisRound - GameManager.worldHighScoreBefore) / (float) GameManager.timeThisRound, 2) * 100 +
                        "%";
                }
                else
                {
                    highScoreInfoText.text += "beat the world high score by ";
                    highScoreInfoText.text +=
                        HelperFunctions.RoundToDecimalPlaces(
                            (GameManager.worldHighScoreBefore - GameManager.timeThisRound) / (float) GameManager.worldHighScoreBefore, 2) * 100 +
                        "%";
                }
            }
            
            highScoreInfoText.text += "\n";

            if (GameManager.personalHighScoreBefore != 0)
            {
                highScoreInfoText.text += "You ";
                if (GameManager.personalHighScoreBefore < GameManager.timeThisRound)
                {
                    highScoreInfoText.text += "were beaten by your personal high score by ";
                    highScoreInfoText.text +=
                        HelperFunctions.RoundToDecimalPlaces(
                            (GameManager.timeThisRound - GameManager.personalHighScoreBefore) / (float) GameManager.timeThisRound,
                            2) * 100 +
                        "%";
                }
                else
                {
                    highScoreInfoText.text += "beat your personal high score by ";
                    highScoreInfoText.text +=
                        HelperFunctions.RoundToDecimalPlaces(
                            (GameManager.personalHighScoreBefore - GameManager.timeThisRound) / (float) GameManager.personalHighScoreBefore, 2) *
                        100 +
                        "%";
                }
            }
        }
    }
}