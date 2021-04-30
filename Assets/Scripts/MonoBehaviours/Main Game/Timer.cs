//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using Classes;
using UnityEngine;
using TMPro;

namespace MonoBehaviours.Main_Game
{
    public class Timer : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        public static Timer Instance { get; private set; }

        public int time = 0;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Debug.LogWarning("There are more than 1 timers in the scene. Make sure there is only one. ");
            }
        }

        private void Start()
        {
            InvokeRepeating(nameof(UpdateTimer), 1f, 1f);
        }

        private void UpdateTimer()
        {
            time++;

            var timeSpan = TimeSpan.FromSeconds(time);
            timerText.text = "Time elapsed: " + HelperFunctions.TimeSpanToShortForm(timeSpan);
        }
    }
}
