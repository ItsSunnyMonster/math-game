//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using UnityEngine;
using TMPro;

namespace MonoBehaviours.Question_Mark
{
    public class QuestionMarkCount : MonoBehaviour
    {
        public TextMeshProUGUI countText;
        public QuestionMarkSpawner questionMarkSpawner;

        private void OnEnable()
        {
            questionMarkSpawner.OnQuestionMarkListUpdate += UpdateCount;
        }

        private void OnDisable()
        {
            questionMarkSpawner.OnQuestionMarkListUpdate -= UpdateCount;
        }

        private void UpdateCount()
        {
            countText.text = questionMarkSpawner.questionMarksInScene.Count + " Question Marks Left";
        }
    }
}