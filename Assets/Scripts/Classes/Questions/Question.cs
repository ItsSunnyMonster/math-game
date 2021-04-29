//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System.Globalization;
using UnityEngine;

namespace Classes.Questions
{
    public enum QuestionType
    {
        TimesTable,
        AdditionOfTwoDigitNumbers,
        ShortDivision,
        SubtractionOfTwoDigitNumbers,
        Sqrt,
        Square,
        Cube,
        ZerothPower
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
                questionBody = multiplier1 + " × " + multiplier2 + " = ? ";

                //setup correct answer
                correctAnswer = (multiplier1 * multiplier2).ToString();
            }
            else if (this.questionType == QuestionType.AdditionOfTwoDigitNumbers)
            {
                //create vars
                var addend1 = Random.Range(0, 100);
                var addend2 = Random.Range(0, 100);

                //setup question body
                questionBody = addend1 + " + " + addend2 + " = ? ";

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
                questionBody = dividend + " ÷ " + divisor + " = ? ";

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
                questionBody = subtrahend + " - " + subtractor + " = ? ";

                //setup correct answer
                correctAnswer = (subtrahend - subtractor).ToString();
            }
            else if (this.questionType == QuestionType.Sqrt)
            {
                //create vars
                var perfectSquare = Random.Range(0, 13);
                var radicand = Mathf.Pow(perfectSquare, 2);
                
                //setup question body
                questionBody = "What is the square root of " + radicand + "?";
                
                //setup correct answer
                correctAnswer = perfectSquare.ToString();
            }
            else if (this.questionType == QuestionType.Square)
            {
                //create vars
                var beforeSquare = Random.Range(0, 13);
                
                //setup question body
                questionBody = beforeSquare + "² = ?";
                
                //setup correct answer
                correctAnswer = Mathf.Pow(beforeSquare, 2).ToString(CultureInfo.InvariantCulture);
            }
            else if (this.questionType == QuestionType.Cube)
            {
                //create vars
                var beforeCube = Random.Range(0, 6);
                
                //setup question body
                questionBody = beforeCube + "³ = ?";
                
                //setup correct answer
                correctAnswer = Mathf.Pow(beforeCube, 3).ToString(CultureInfo.InvariantCulture);
            }
            else if (this.questionType == QuestionType.ZerothPower)
            {
                //create vars
                var beforeZerothPower = Random.Range(1, 999999999);
                
                //setup question body
                questionBody = "What is " + beforeZerothPower + " to the 0th power?";
                
                //setup correct answer
                correctAnswer = "1";
            }
        }
    }
}