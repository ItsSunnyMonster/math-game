//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestionGenerator))]
public class QuestionGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var questionGen = (QuestionGenerator)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Display Question"))
        {
            questionGen.DisplayQuestion();
        }
    }
}

