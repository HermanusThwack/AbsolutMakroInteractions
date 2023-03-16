using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;

public enum AnswersWeights
{
    Original,
    Watermelon,
    Grapefruit,
    Raspberri,
    Lime
}

[Serializable]
public class Question
{
    [SerializeField]
    private string prompt;
    [SerializeField]
    private string responseOne, responseTwo, responseThree, responseFour;

    public QuestionsSO questionData;

    [SerializeField]
    private AnswersWeights[] responseOneWeights = new AnswersWeights[0];
    [SerializeField]
    private AnswersWeights[] responseTwoWeights = new AnswersWeights[0];
    [SerializeField]
    private AnswersWeights[] responseThreeWeights = new AnswersWeights[0];
    [SerializeField]
    private AnswersWeights[] reponseFourWeights = new AnswersWeights[0];

    #region Properties
    public string Prompt { get => prompt; set => prompt = value; }
    public string ResponseOne { get => responseOne; set => responseOne = value; }
    public string ResponseTwo { get => responseTwo; set => responseTwo = value; }
    public string ResponseThree { get => responseThree; set => responseThree = value; }
    public string ResponseFour { get => responseFour; set => responseFour = value; }


    public AnswersWeights[] ResponseOneWeights { get => responseOneWeights; }
    public AnswersWeights[] ResponseTwoWeights { get => responseTwoWeights; }
    public AnswersWeights[] ResponseThreeWeights { get => responseThreeWeights; }
    public AnswersWeights[] ResponseFourWeights { get => reponseFourWeights; }
    #endregion

}


public class Quiz : UIScreen
{

    [SerializeField]
    private TextMeshProUGUI prompt;

    [SerializeField]
    private GameObject[] responses = new GameObject[4];
    [SerializeField]
    private GameObject[] resultObjects = new GameObject[5];
    [SerializeField]
    private int promptCount = 0;
    [SerializeField]
    private int tieCheck = 2;
    [Header("Quiz Components"), SerializeField]
    private int oWeight = 0;
    [SerializeField]
    private int wWeight = 0, rWeight = 0, lWeight = 0, gWeight = 0;


    [SerializeField]
    private Question[] questions = new Question[0];


    [SerializeField]
    private Question currentQuestion;
    #region Properties
    public Question[] Questions { get => questions; }
    #endregion


    public void TakeQuiz()
    {
        responses[4].SetActive(true); 
        for (int i = 0; i < resultObjects.Length; i++)
        {
            resultObjects[i].SetActive(false);
        }
        tieCheck = 2;
        oWeight = 0; wWeight = 0; rWeight = 0; lWeight = 0; gWeight = 0;
        promptCount = 0;
        SetCurrentQuestion(promptCount);
        InitializeQuestions();
    }

    public void SetCurrentQuestion(int promptIndex)
    {

        currentQuestion = questions[promptIndex];

    }

    private void InitializeQuestions()
    {

        prompt.text = currentQuestion.Prompt;
        responses[0].gameObject.SetActive(true);
        var responseOneText = responses[0].GetComponentInChildren<TextMeshProUGUI>();
        var responseOneButton = responses[0].GetComponent<Button>();
        responseOneButton.onClick.RemoveAllListeners();

        responseOneButton.onClick.AddListener(() => AssignButton(1));
        responseOneText.text = currentQuestion.ResponseOne;

        responses[1].gameObject.SetActive(true);
        var responseTwoButton = responses[1].GetComponent<Button>();
        var responseTwoText = responses[1].GetComponentInChildren<TextMeshProUGUI>();


        responseTwoButton.onClick.RemoveAllListeners();
        responseTwoButton.onClick.AddListener(() => AssignButton(2));
        responseTwoText.text = currentQuestion.ResponseTwo;


        if (currentQuestion.ResponseThree == "null")
        {
            responses[2].gameObject.SetActive(false);


        }
        else
        {
            responses[2].gameObject.SetActive(true);
            var responseThreeText = responses[2].GetComponentInChildren<TextMeshProUGUI>();
            var responseThreeButton = responses[2].GetComponent<Button>();

            responseThreeButton.onClick.RemoveAllListeners();

            responseThreeButton.onClick.AddListener(() => AssignButton(3));
            responseThreeText.text = currentQuestion.ResponseThree;
        }

        if (currentQuestion.ResponseFour == "null")
        {
            responses[3].gameObject.SetActive(false);

        }
        else
        {
            responses[3].gameObject.SetActive(true);
            var responseFourText = responses[3].GetComponentInChildren<TextMeshProUGUI>();

            var responseFourButton = responses[3].GetComponent<Button>();

            responseFourButton.onClick.RemoveAllListeners();

            responseFourButton.onClick.AddListener(() => AssignButton(4));
            responseFourText.text = currentQuestion.ResponseFour;
        }
    }

    private void AssignButton(int _responseNumber)
    {
        if (currentQuestion == null)
        {
            return;
        }

        AnswersWeights[] responseWeights;

        switch (_responseNumber)
        {
            case 1:
                responseWeights = currentQuestion.ResponseOneWeights;
                break;
            case 2:
                responseWeights = currentQuestion.ResponseTwoWeights;
                break;
            case 3:
                responseWeights = currentQuestion.ResponseThreeWeights;
                break;
            case 4:
                responseWeights = currentQuestion.ResponseFourWeights;
                break;
            default:
                return;
        }

        foreach (AnswersWeights answerWeight in responseWeights)
        {
            switch (answerWeight)
            {
                case AnswersWeights.Original:
                    oWeight++;
                    break;
                case AnswersWeights.Watermelon:
                    wWeight++;
                    break;
                case AnswersWeights.Raspberri:
                    rWeight++;
                    break;
                case AnswersWeights.Lime:
                    lWeight++;
                    break;
                case AnswersWeights.Grapefruit:
                    gWeight++;
                    break;
                default:
                    break;
            }
        }
        /// Check result
        if (promptCount == tieCheck)
        {
            if (CheckResult().Item1)
            {
                promptCount++;
                SetCurrentQuestion(promptCount);
                InitializeQuestions();
                tieCheck++;
            }
            else
            {
                DisplayResult(CheckResult().Item2);

            }

            return;

        }

        promptCount++;
        SetCurrentQuestion(promptCount);
        InitializeQuestions();
    }


    private (bool, int) CheckResult()
    {
        int[] weightedValues = { oWeight, wWeight, rWeight, lWeight, gWeight };

        int heighestValue = weightedValues[0];
        int heighestIndex = 0;
        bool tied = false;

        for (int i = 1; i < weightedValues.Length; i++)
        {
            if (weightedValues[i] > heighestValue)
            {
                heighestValue = weightedValues[i];
                heighestIndex = i;
                tied = false;
            }
            else if (weightedValues[i] == heighestValue)
            {
                tied = true;
            }
        }

        if (tied)
        {
            return (true, heighestIndex);
        }
        else
        {
            return (false, heighestIndex);
        }
    }


    private void DisplayResult(int index)
    {
       

        for (int i = 0; i < responses.Length; i++)
        {
            responses[i].SetActive(false);
        }

        resultObjects[5].SetActive(true);
        switch (index)
        {
            case 0:
                Debug.Log("Original" + index);
                resultObjects[0].SetActive(true);
                break;
            case 1:
                Debug.Log("Watermelon" + index);
                resultObjects[1].SetActive(true);
                break;
            case 2:
                Debug.Log("Raspberri" + index);
                resultObjects[2].SetActive(true);
                break;
            case 3:
                Debug.Log("Lime" + index);
                resultObjects[3].SetActive(true);
                break;

            case 4:
                Debug.Log("Grapefruit" + index);
                resultObjects[4].SetActive(true);
                break;

        }
    }
}
