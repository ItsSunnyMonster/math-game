//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public QuestionGenerator questionGenerator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionGenerator.DisplayQuestion();
        }
    }
}