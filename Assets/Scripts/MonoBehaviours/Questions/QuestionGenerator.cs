//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System.Collections;
using Classes.Questions;
using MonoBehaviours.Main_Game;
using MonoBehaviours.Question_Mark;
using TMPro;
using UnityEngine;

namespace MonoBehaviours.Questions
{
    //where did the question request come from
    public enum QuestionRequestComesFrom
    {
        Questions,
        Maze
    }

    public class QuestionGenerator : MonoBehaviour
    {
        public static QuestionGenerator Instance { get; private set; }
        public QuestionType[] easyQuestionTypes;
        public QuestionType[] hardQuestionTypes;
        public TextMeshProUGUI questionDisplay;
        public TextMeshProUGUI correctOrNot;
        public TMP_InputField inputField;
        public GameObject continueButton;
        public Animator questionPanelAnimator;
        public QuestionMarkSpawner questionMarkSpawner;

        public bool IsQuestionPanelEnabled { get; private set; } = false;

        private Question _question;
        private static readonly int Enable = Animator.StringToHash("Enable");
        private static readonly int Disable = Animator.StringToHash("Disable");
        private bool correct;

        private void Awake()
        {
            //set singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            } 
        }

        private Question GetQuestionFromType(QuestionType questionType)
        {
            //create a new question with type of questionType and return
            return new Question(questionType);
        }

        public void DisplayQuestion(bool isQuestionHard)
        {
            //enable panel
            EnableQuestionPanel();

            //setup question
            _question = GetQuestionFromType(isQuestionHard
                ? hardQuestionTypes[Random.Range(0, hardQuestionTypes.Length)]
                : easyQuestionTypes[Random.Range(0, easyQuestionTypes.Length)]);

            //setup UI
            questionDisplay.text = _question.questionBody;
            inputField.text = "";
            //have to wait a frame to select input field
            StartCoroutine(SelectInputField());
            correctOrNot.text = "";
            continueButton.SetActive(false);
        }

        private IEnumerator SelectInputField()
        {
            //wait a frame
            yield return null;
            
            //select input field
            inputField.Select();
        }

        //called when user clicks submit button
        public void OnSubmit()
        {
            //null and empty check
            if (string.IsNullOrEmpty(inputField.text) || string.IsNullOrEmpty(_question.correctAnswer))
                return;

            //answer check
            if (inputField.text == _question.correctAnswer)
            {
                correctOrNot.text = "You are correct! ";
                correct = true;
            }
            else
            {
                correctOrNot.text = "The correct answer is " + _question.correctAnswer;
                correct = false;
            }

            //enable "continue" button
            continueButton.SetActive(true);
        }

        //called when continue is clicked
        public void OnContinue()
        {
            DisableQuestionPanel();
            if (correct)
            {
                if (questionMarkSpawner.questionMarksInScene.Count == 0)
                {
                    GameManager.Instance.GameOver();
                }
                return;
            }
            for (var i = 0; i < 2; i++)
            {
                questionMarkSpawner.SpawnQuestionMark();
            }
        }
        
        private void EnableQuestionPanel()
        {
            questionPanelAnimator.SetTrigger(Enable);
            IsQuestionPanelEnabled = true;
        }

        public void DisableQuestionPanel()
        {
            questionPanelAnimator.SetTrigger(Disable);
            IsQuestionPanelEnabled = false;
        }
    }
}