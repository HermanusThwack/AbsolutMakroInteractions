using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [Header("Components"),SerializeField]
    protected Animator anim;

    [SerializeField]
    protected List<GameObject> screenToTurnOn = new List<GameObject>();


    public virtual void ActivateScreen()
    {
        for (int i = 0; i < screenToTurnOn.Count; i++)
        {
            screenToTurnOn[i].SetActive(true);
        }

    }

    public virtual void DeactivateScreen()
    {
        for (int i = 0; i < screenToTurnOn.Count; i++)
        {
            screenToTurnOn[i].SetActive(false);
        }

    }
}
