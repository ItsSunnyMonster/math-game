//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using UnityEngine;

public enum QuestionType
{
    TimesTable,
    AdditionOfTwoDigitNumbers,
    ShortDivision,
    SubtractionOfTwoDigitNumbers
}

public class Question
{
    public readonly QuestionType questionType;
    public readonly string questionBody;
    public readonly string correctAnswer;

    //constructor
    public Question(QuestionType questionType)
    {
        this.questionType = questionType;

        if (this.questionType == QuestionType.TimesTable)
        {
            //create vars
            var multiplier1 = Random.Range(0, 11);
            var multiplier2 = Random.Range(0, 11);

            //setup question body
            questionBody = multiplier1.ToString() + " × " + multiplier2.ToString() + " = ? ";

            //setup correct answer
            correctAnswer = (multiplier1 * multiplier2).ToString();
        }
        else if (this.questionType == QuestionType.AdditionOfTwoDigitNumbers)
        {
            //create vars
            var addend1 = Random.Range(0, 100);
            var addend2 = Random.Range(0, 100);

            //setup question body
            questionBody = addend1.ToString() + " + " + addend2.ToString() + " = ? ";

            //setup correct answer
            correctAnswer = (addend1 + addend2).ToString();
        }
        else if (this.questionType == QuestionType.ShortDivision)
        {
            //create vars
            var dividend = Random.Range(0, 101);
            var divisor = Random.Range(1, 11);

            //check numbers
            if ((dividend < divisor) || (dividend % divisor != 0))
            {
                //regenerate numbers
                while ((dividend < divisor) || ((dividend % divisor) != 0))
                {
                    dividend = Random.Range(0, 101);
                    divisor = Random.Range(1, 11);
                }
            }

            //setup question body
            questionBody = dividend.ToString() + " ÷ " + divisor.ToString() + " = ? ";

            //setup correct answer
            correctAnswer = (dividend / divisor).ToString();
        }
        else if (this.questionType == QuestionType.SubtractionOfTwoDigitNumbers)
        {
            //create vars
            var subtrahend = Random.Range(0, 100);
            var subtractor = Random.Range(0, 100);

            //check numbers
            if (subtrahend < subtractor)
            {
                while (subtrahend < subtractor)
                {
                    //regenerate numbers
                    subtrahend = Random.Range(0, 100);
                    subtractor = Random.Range(0, 100);
                }
            }

            //setup question body
            questionBody = subtrahend.ToString() + " - " + subtractor.ToString() + " = ? ";

            //setup correct answer
            correctAnswer = (subtrahend - subtractor).ToString();
        }
    }
}