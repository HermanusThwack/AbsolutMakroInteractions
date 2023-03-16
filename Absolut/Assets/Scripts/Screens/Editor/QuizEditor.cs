using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using static PlasticGui.WorkspaceWindow.CodeReview.Summary.CommentSummaryData;

[CustomEditor(typeof(Quiz))]
public class QuizEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Quiz myScript = (Quiz)target;

        PopulateData(myScript);

    }

    private static void PopulateData(Quiz myScript)
    {
        for (int i = 0; i < myScript.Questions.Length; i++)
        {

            if (myScript.Questions[i].questionData != null)
            {
                myScript.Questions[i].Prompt = myScript.Questions[i].questionData.Prompt;
                myScript.Questions[i].ResponseOne = myScript.Questions[i].questionData.ResponseOne;
                myScript.Questions[i].ResponseTwo = myScript.Questions[i].questionData.ResponseTwo;
                myScript.Questions[i].ResponseThree = myScript.Questions[i].questionData.ResponseThree;
                myScript.Questions[i].ResponseFour = myScript.Questions[i].questionData.ResponseFour;
            }
            else
            {
                myScript.Questions[i].Prompt = string.Empty;
                myScript.Questions[i].ResponseOne = string.Empty;
                myScript.Questions[i].ResponseTwo = string.Empty;
                myScript.Questions[i].ResponseThree = string.Empty;
                myScript.Questions[i].ResponseFour = string.Empty;
            }
  
        }
    }
}

