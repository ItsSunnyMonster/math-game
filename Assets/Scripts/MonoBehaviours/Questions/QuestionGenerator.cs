//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System.Collections;
using TMPro;
using UnityEngine;

//where did the question request come from
public enum QuestionRequestComesFrom
{
    Questions,
    Maze
}

public class QuestionGenerator : MonoBehaviour
{
    public static QuestionGenerator instance { get; private set; }
    public QuestionType[] questionTypes;
    public TextMeshProUGUI questionDisplay;
    public TextMeshProUGUI correctOrNot;
    public TMP_InputField inputField;
    public GameObject continueButton;
    public GameObject quitButton;
    public Animator questionPanelAnimator;

    public bool isQuestionPanelEnabled { get; private set; } = false;

    private Question question;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public Question GetQuestionFromType(QuestionType questionType)
    {
        return new Question(questionType);
    }

    public void DisplayQuestion()
    {
        EnableQuestionPanel();

        //setup question
        question = GetQuestionFromType(questionTypes[Random.Range(0, questionTypes.Length)]);

        //setup UI
        questionDisplay.text = question.questionBody;
        inputField.text = "";
        StartCoroutine(SelectInputField());
        correctOrNot.text = "";
        continueButton.SetActive(false);
    }

    private IEnumerator SelectInputField()
    {
        yield return null;
        inputField.Select();
    }

    //called when user clicks submit button
    public void OnSubmit()
    {
        //null and empty check
        if (inputField.text == null || inputField.text == "" || question.correctAnswer == null || question.correctAnswer == "")
            return;

        //answer check
        if (inputField.text == question.correctAnswer)
        {
            correctOrNot.text = "You are correct! ";
        }
        else
        {
            correctOrNot.text = "The correct answer is " + question.correctAnswer;
        }

        //enable "continue" button
        continueButton.SetActive(true);
    }

    //called when continue is clicked
    public void OnContinue()
    {
        DisableQuestionPanel();
    }

    private void EnableQuestionPanel()
    {
        questionPanelAnimator.SetTrigger("Enable");
        isQuestionPanelEnabled = true;
    }

    public void DisableQuestionPanel()
    {
        questionPanelAnimator.SetTrigger("Disable");
        isQuestionPanelEnabled = false;
    }
}