using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public enum HomeScreenOptions
{
    OurRange,
    Cocktails,
    Quiz  // Find your perfect mix.
}


public class HomeScreen : UIScreen
{
    [SerializeField]
    private HomeScreenOptions currentHomeScreenOptions;

    [SerializeField]
    private TextMeshProUGUI optionName;

    [SerializeField]
    private Button selectionButton;
    public override void ActivateScreen()
    {
        base.ActivateScreen();
        ChangeToOurRange();
    }

    private void SetOption()
    {
        switch (currentHomeScreenOptions)
        {
            case HomeScreenOptions.OurRange:
                TransitionOption("OurRange");
                selectionButton.onClick.RemoveAllListeners();
                selectionButton.onClick.AddListener(UIStateMachine.Instance.ChangeToOurRange);
                break;
            case HomeScreenOptions.Cocktails:
                TransitionOption("Cocktails");
                selectionButton.onClick.RemoveAllListeners();
                selectionButton.onClick.AddListener(UIStateMachine.Instance.ChangeToCocktails);
                break;
            case HomeScreenOptions.Quiz:
                TransitionOption("Your out your\nperfect flavour");
                selectionButton.onClick.RemoveAllListeners();
                selectionButton.onClick.AddListener(UIStateMachine.Instance.ChangeToQuiz);
                break;
        }
    }

    private void TransitionOption(string newOption)
    {
        if (anim != null)
        {
            anim.CrossFade("AnimateOut", 0.1f);

            if (optionName != null)
            {

                optionName.text = newOption;
            }
        }

    }

    public void ChangeOption(HomeScreenOptions newOption)
    {
        currentHomeScreenOptions = newOption;
        SetOption();
    }


    public void ChangeToOurRange()
    {
        ChangeOption(HomeScreenOptions.OurRange);
    }
    public void ChangeToCocktails()
    {
        ChangeOption(HomeScreenOptions.Cocktails);
    }
    public void ChangeToQuiz()
    {
        ChangeOption(HomeScreenOptions.Quiz);
    }
}


