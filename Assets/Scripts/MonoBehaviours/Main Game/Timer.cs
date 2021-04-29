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
        
        private int _seconds = 0;

        private void Start()
        {
            InvokeRepeating(nameof(UpdateTimer), 1f, 1f);
        }

        private void UpdateTimer()
        {
            _seconds++;

            var timeSpan = TimeSpan.FromSeconds(_seconds);
            timerText.text = "Time elapsed: " + HelperFunctions.TimeSpanToShortForm(timeSpan);
        }
    }
}
