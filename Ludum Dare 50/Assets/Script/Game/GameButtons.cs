using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    [SerializeField]Button btn;
    [SerializeField]ScenarioOne scenarioOne;
    [SerializeField]ScenarioTwo scenarioTwo;
    [SerializeField]ScenarioThree scenarioThree;
    [SerializeField] GameObject phoneDown;
    [SerializeField] GameObject phoneUp;

    private void Start()
    {
        phoneDown.SetActive(true);
        phoneUp.SetActive(false);
    }

    public void InitialConfirm()
    {
        GameManager.instance.contentWarningPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AnswerPhone()
    {
        GameManager.instance.phonepickedUp = true;
        phoneDown.SetActive(false);
        phoneUp.SetActive(true);
    }

    public void HangupPhone()
    {
        GameManager.instance.phoneHangUp = true;
        
        phoneUp.SetActive(false);
        phoneDown.SetActive(true);
    }

    public void ButnOne()
    {
        GameManager.instance.MoveDown();
        GameManager.instance.btnPressed = 1;
    }

    public void ButnTwo()
    {
        GameManager.instance.MoveDown();
        GameManager.instance.btnPressed = 2;
        GameManager.instance.remainedQuiet += 1;
        if (GameManager.instance.remainedQuiet >= 3)
        {
            if (GameManager.instance.scenario == GameManager.Scenario.One)
            {
                scenarioOne.dialogueTracker = 999;
            }
            if (GameManager.instance.scenario == GameManager.Scenario.Two)
            {
                scenarioTwo.dialogueTracker = 999;
            }
            if (GameManager.instance.scenario == GameManager.Scenario.Three)
            {
                scenarioThree.dialogueTracker = 999;
            }
        }
    }

    public void ButnThree()
    {
        GameManager.instance.MoveDown();
        GameManager.instance.btnPressed = 3;
    }

    public void ButnFour()
    {
        GameManager.instance.btnPressed = 4;
        btn.interactable = false;
        if (GameManager.instance.scenario == GameManager.Scenario.One)
        {
            scenarioOne.dialogueTracker = 99;
        }
        if (GameManager.instance.scenario == GameManager.Scenario.Two)
        {
            scenarioTwo.dialogueTracker = 99;
        }
        if (GameManager.instance.scenario == GameManager.Scenario.Three)
        {
            scenarioThree.dialogueTracker = 99;
        }
        //start the dispatch timer
    }
}
