//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using MonoBehaviours.Questions;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(QuestionGenerator))]
    public class QuestionGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            //question generator
            var questionGen = (QuestionGenerator)target;

            DrawDefaultInspector();
            
            if (GUILayout.Button("Display Question"))
            {
                questionGen.DisplayQuestion(true);
            }
        }
    }
}

