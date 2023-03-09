using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
//Pseudo state machine.

public enum UI_States
{
    None,
    HomeScreen,
    OurRange,
    Cocktails,
    Quiz,
    ProductDescription,
    MostPopularCocktails,
    CocktailDescription,
    QRCode
}

public class UIStateMachine : Singleton<UIStateMachine>
{
    [SerializeField]
    private UI_States state = UI_States.None;

    [SerializeField]
    private List<UIScreen> screens = new List<UIScreen>();

    [SerializeField, Header("Debugging")]
    private UIScreen screenSwap;

    [SerializeField]
    private bool screenOptionOne = true;
    [SerializeField]
    private UIScreen activeScreen = null;


    public bool ScreenOptionOne { get => screenOptionOne; set => screenOptionOne = value; }

    private void Start()
    {
        if (ScreenOptionOne)
        {
            ChangeCurrentState(UI_States.HomeScreen);
        }
        else
        {
            activeScreen = screenSwap;
            ChangeCurrentState(UI_States.HomeScreen);
        }

     
    }



    /// <summary>
    /// Change current state to new UI State
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeCurrentState(UI_States newState)
    {
        state = newState;
        StateHandling();
    }

    private void StateHandling()
    {
        switch (state)
        {
            case UI_States.HomeScreen:
                if (screenOptionOne)
                {
                    screenSwap.DeactivateScreen();
                    EnableScreen("HomeScreen");
                    if (activeScreen != null)
                    {
                        activeScreen.ActivateScreen();
                    }
                }
                else
                {
                    ChangeActiveScreen();
                  
                    if (activeScreen != null)
                    {
                        activeScreen.ActivateScreen();
                    }
                }
                break;
            case UI_States.OurRange:
                EnableScreen("OurRange");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;
            case UI_States.Cocktails:
                EnableScreen("Cocktails");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;
            case UI_States.Quiz:
                EnableScreen("Quiz");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;
            case UI_States.ProductDescription:
                EnableScreen("ProductDescription");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;
            case UI_States.MostPopularCocktails:
                EnableScreen("MostPopularCocktails");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;

            case UI_States.CocktailDescription:
                EnableScreen("CocktailDescription");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;
            case UI_States.QRCode:
                EnableScreen("QRCode");
                if (activeScreen != null)
                {
                    activeScreen.ActivateScreen();
                }
                break;


        }
    }
    private void EnableScreen(string screenName)
    {
        if(!screenOptionOne) screenSwap.DeactivateScreen();
        for (int i = 0; i < screens.Count; i++)
        {
            if (screens[i].name == screenName)
            {
                screens[i].enabled = true;
                activeScreen = screens[i];
            }
            else
            {
                screens[i].DeactivateScreen();
                screens[i].enabled = false;
            }

        }
    }

    public void ChangeActiveScreen()
    {
        activeScreen = screenSwap;

        for (int i = 0; i < screens.Count; i++)
        {
            screens[i].DeactivateScreen();
            screens[i].enabled = false;
        }
    }

    #region ChangeScreens
    public void ChangeToHomeScreen()
    {
        ChangeCurrentState(UI_States.HomeScreen);
    }

    public void ChangeToOurRange()
    {
        ChangeCurrentState(UI_States.OurRange);
    }
    public void ChangeToCocktails()
    {
        ChangeCurrentState(UI_States.Cocktails);
    }

    public void ChangeToQuiz()
    {
        ChangeCurrentState(UI_States.Quiz);
    }
    public void ChangeToProductDescription()
    {
        ChangeCurrentState(UI_States.ProductDescription);
    }
    public void ChangeToMostPopularCocktails()
    {
        ChangeCurrentState(UI_States.MostPopularCocktails);
    }
    public void ChangeToMostCocktailDescription()
    {
        ChangeCurrentState(UI_States.CocktailDescription);
    }
    public void ChangeToMostQRCode()
    {
        ChangeCurrentState(UI_States.QRCode);
    }

    #endregion
}
