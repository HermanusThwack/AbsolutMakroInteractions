using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    [SerializeField]
    private Image buttonPressed;

    [SerializeField]
    private Color pressedColour , startColour;



    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Closing");
    }

    public void ChangeHomeScreen()
    {
        UIStateMachine.Instance.ScreenOptionOne = !UIStateMachine.Instance.ScreenOptionOne;

        if (buttonPressed.color == startColour)
        {
            buttonPressed.color = pressedColour;
        }
        else
        {
            buttonPressed.color = startColour;
        }

    }
}
