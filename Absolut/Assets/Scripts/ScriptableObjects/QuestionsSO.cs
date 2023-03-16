using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Question Data")]
public class QuestionsSO : ScriptableObject
{
    public string Prompt;

    public string ResponseOne,ResponseTwo,ResponseThree,ResponseFour;

}
