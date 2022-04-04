using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScenarioTwo : MonoBehaviour
{
    [SerializeField] float timer = 0.0f;
    float timerMax = 0.0f;

    [SerializeField] float secnarioTimer = 0f;
    float scenarioTimermax = 0f;

    public TMP_Text textBox;

    public string displayText;

    public List<string> dialogue;
    public List<string> dialogue2;
    public List<string> dialogue3;
    public List<string> dialogue4;
    public List<string> dialogue5;
    public List<string> dialogue6;

    public int dialogueTracker = 0;
    int diaTrackerCurrent;

    [SerializeField] float diaTimer = 0f;
    float diaTimerMax = 0f;

    [SerializeField] TMP_Text btn1Txt;
    [SerializeField] TMP_Text btn2Txt;
    [SerializeField] TMP_Text btn3Txt;
    [SerializeField] TMP_Text btn4Txt;

    bool increaseTrackernumber;

    float options = 1;
    int dialogueOption;

    private void Start()
    {
        GameManager.instance.phonepickedUp = false;
        displayText = "Ring Ring... Ring Ring...";
    }

    private void Update()
    {
        int gmBtn = GameManager.instance.btnPressed;
        secnarioTimer += Time.deltaTime * 1f;

        if (GameManager.instance.remainedQuiet >= 3)
        {

            SuicideTalk();
        }

        if (!GameManager.instance.phonepickedUp)
        {
            textBox.text = displayText;
            timerMax = 60f;
            timer += Time.deltaTime * 1f;
            if (timer >= timerMax)
            {

                GameManager.instance.scenarioTwoFailed = true;
                GameManager.instance.scenarioOver = true;

            }
        }
        else
        {
            //dial one
            if (dialogueTracker == 0)
            {
                diaTimer += Time.deltaTime * 1f;
                diaTimerMax = 6f;
                displayText = dialogue[0];
                increaseTrackernumber = true;
            }
            else if (dialogueTracker == 1)
            {
                diaTrackerCurrent = dialogueTracker;
                options = 1;

                diaTimer += Time.deltaTime * 1f;
                diaTimerMax = 6f;
                displayText = dialogue[1];

                ShowBtnOptions();
                GameManager.instance.MoveUp();

                if (gmBtn == 0)
                {
                    increaseTrackernumber = false;
                }
                else
                {
                    GameManager.instance.MoveDown();
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 2)//dial two
            {
                if (gmBtn == 1)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    dialogueOption = 1;
                    GameManager.instance.btnPressed = 0;
                    displayText = dialogue2[0];
                }
                if (gmBtn == 2)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    dialogueOption = 2;
                    GameManager.instance.btnPressed = 0;
                    displayText = dialogue2[1];
                }
                if (gmBtn == 3)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    dialogueOption = 3;
                    GameManager.instance.btnPressed = 0;
                    displayText = dialogue2[2];
                }

                if (dialogueOption != 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = true;
                }

            }
            else if (dialogueTracker == 3)
            {
                if (dialogueOption == 1)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 2;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;


                    displayText = dialogue2[4];
                }
                if (dialogueOption == 2)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 2;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue2[5];
                }
                if (dialogueOption == 3)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 2;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue2[6];
                }

                ShowBtnOptions();
                GameManager.instance.MoveUp();

                if (gmBtn == 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = false;
                }
                else
                {
                    GameManager.instance.MoveDown();
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 4)//dial 3
            {
                if (gmBtn == 1)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 1;
                    displayText = dialogue3[0];
                }
                if (gmBtn == 2)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 2;
                    displayText = dialogue3[1];
                }
                if (gmBtn == 3)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 3;
                    displayText = dialogue3[2];
                }

                if (dialogueOption != 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 5)
            {
                if (dialogueOption == 1)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 3;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 12f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue3[3];
                }
                if (dialogueOption == 2)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 3f;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    // GameManager.instance.btnPressed = 0;
                    displayText = dialogue3[4];
                }
                if (dialogueOption == 3)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 3;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue3[5];
                }

                ShowBtnOptions();
                GameManager.instance.MoveUp();

                if (gmBtn == 0)
                {
                    increaseTrackernumber = false;
                }
                else
                {
                    GameManager.instance.MoveDown();
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 6)//dial four
            {
                if (gmBtn == 1)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 18f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 1;
                    displayText = dialogue4[0];
                }
                if (gmBtn == 2)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 2;
                    displayText = dialogue4[1];
                }
                if (gmBtn == 3)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 3;
                    displayText = dialogue4[2];
                }

                if (dialogueOption != 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 7)
            {
                if (dialogueOption == 1)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 4;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue4[3];
                }
                if (dialogueOption == 2)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 4;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    // GameManager.instance.btnPressed = 0;
                    displayText = dialogue4[4];
                }
                if (dialogueOption == 3)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 4;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue4[5];
                }

                ShowBtnOptions();
                GameManager.instance.MoveUp();

                if (gmBtn == 0)
                {
                    increaseTrackernumber = false;
                }
                else
                {
                    GameManager.instance.MoveDown();
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 8) //dial 5
            {
                if (gmBtn == 1)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 12f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 1;
                    
                        displayText = dialogue5[0];
                    
                }
                if (gmBtn == 2)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 2;
                    displayText = dialogue5[1];
                }
                if (gmBtn == 3)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 3;
                    displayText = dialogue5[2];
                }

                if (dialogueOption != 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 9)
            {
                if (dialogueOption == 1)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 5;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    
                    displayText = dialogue5[3];
                    
                    
                }
                if (dialogueOption == 2)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 5;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue5[4];
                }
                if (dialogueOption == 3)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 5;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue5[5];
                }

                ShowBtnOptions();
                GameManager.instance.MoveUp();

                if (gmBtn == 0)
                {
                    increaseTrackernumber = false;
                }
                else
                {
                    GameManager.instance.MoveDown();
                    increaseTrackernumber = true;
                }
            }
            else if(dialogueTracker == 10)//dial 6
            {
                if (gmBtn == 1)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 12f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 1;
                    
                        displayText = dialogue6[0];
                    
                }
                if (gmBtn == 2)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 2;
                    displayText = dialogue6[1];
                }
                if (gmBtn == 3)
                {
                    increaseTrackernumber = true;
                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;
                    GameManager.instance.btnPressed = 0;
                    dialogueOption = 3;
                    displayText = dialogue6[2];
                }

                if (dialogueOption != 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = true;
                }
            }
            else if(dialogueTracker == 11)
            {
                if (dialogueOption == 1)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 5;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    displayText = dialogue6[3];


                }
                if (dialogueOption == 2)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 5;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue6[4];
                }
                if (dialogueOption == 3)
                {
                    diaTrackerCurrent = dialogueTracker;
                    options = 5;

                    diaTimer += Time.deltaTime * 1f;
                    diaTimerMax = 6f;

                    //GameManager.instance.btnPressed = 0;
                    displayText = dialogue6[5];
                }

                if (dialogueOption != 0)
                {
                    diaTimer += Time.deltaTime * 1f;
                    increaseTrackernumber = true;
                }
            }
            else if (dialogueTracker == 12)
            {
                displayText = "Thank you for calling if you have any issues please do not hesitate to call us again any day and time. We are here to help you. Have a wonderful day";
                diaTimer += Time.deltaTime * 1f;
                diaTimerMax = 6f;
                if (diaTimer >= diaTimerMax)
                {
                    GameManager.instance.scenarioTwoFailed = false;
                    GameManager.instance.scenarioOver = true;
                }
            }

            Dispatch();

            textBox.text = displayText;

            if (diaTimer >= diaTimerMax)
            {
                if (!increaseTrackernumber)
                {
                    return;
                }
                else
                {
                    diaTimer = 0f;
                    dialogueTracker += 1;
                }
            }

        }
    }

    void ShowBtnOptions()
    {
        if (options == 1)
        {
            btn1Txt.text = "Hello Chris";
            btn2Txt.text = "Stay Silent";
            btn3Txt.text = "Pleasure";
            btn4Txt.text = "Dispatch";
        }
        else if (options == 2)
        {
            btn1Txt.text = "Not necessarily";
            btn2Txt.text = "Remain quiet";
            btn3Txt.text = "If you want";
            btn4Txt.text = "Dispatch";
        }
        else if (options == 3)
        {
            btn1Txt.text = "Ask about depression";
            btn2Txt.text = "Remain silent";
            btn3Txt.text = "Can not make prescriptions";
            btn4Txt.text = "Dispatch";
        }
        else if (options == 4)
        {
            btn1Txt.text = "Recall the day";
            btn2Txt.text = "Stay silent";
            btn3Txt.text = "When did your depression start";
            btn4Txt.text = "Dispatch";
        }
        else if(options == 5)
        {
            btn1Txt.text = "Looks like you found a cause";
            btn2Txt.text = "Stay silent";
            btn3Txt.text = "Avoid that place";
            btn4Txt.text = "Dispatch";
        }
    }

    void Dispatch()
    {
        if (dialogueTracker == 99)
        {
            if (GameManager.instance.btnPressed == 4)
            {
                diaTimer += Time.deltaTime * 1f;
                displayText = dialogue2[3];
                increaseTrackernumber = true;
            }


        }
        if (dialogueTracker == 100)
        {
            if (GameManager.instance.btnPressed == 4)
            {
                diaTimer += Time.deltaTime * 1f;
                displayText = dialogue2[7];

            }
        }
        if (diaTimer >= diaTimerMax)
        {
            if (!increaseTrackernumber)
            {
                return;
            }
            else
            {
                if (dialogueTracker == 100)
                {
                    dialogueTracker = diaTrackerCurrent;
                    GameManager.instance.btnPressed = 0;
                }
                else
                {
                    diaTimer = 0f;
                    dialogueTracker += 1;
                }
            }
        }
    }

    void SuicideTalk()
    {
        if (dialogueTracker == 999)
        {
            diaTimer += Time.deltaTime * 1f;
            diaTimerMax = 12f;
            increaseTrackernumber = true;
            displayText = "Caller: Seriously just gonna ignore me again!";
        }
        if (dialogueTracker == 1000)
        {
            diaTimer += Time.deltaTime * 1f;
            diaTimerMax = 6f;
            increaseTrackernumber = true;
            displayText = "Caller: Fuck you asshole!";
        }
        if (dialogueTracker == 1001)
        {
            diaTimer += Time.deltaTime * 1f;
            diaTimerMax = 6f;
            increaseTrackernumber = true;
            displayText = "Caller: I figured out how to deal with my depression.";
        }
        if (dialogueTracker == 1002)
        {
            diaTimer += Time.deltaTime * 1f;
            diaTimerMax = 6f;
            increaseTrackernumber = true;
            displayText = "Caller: I guess I am not wanted just like when my parents fucking left me at a fast food joint years ago!";
        }
        if (dialogueTracker == 1003)
        {
            diaTimer += Time.deltaTime * 1f;
            diaTimerMax = 6f;
            increaseTrackernumber = true;
            displayText = "Caller: (Something metal clicks.)";
        }
        if (dialogueTracker == 1004)
        {
            diaTimer += Time.deltaTime * 1f;
            increaseTrackernumber = true;
            displayText = "Caller: (You hear a ear shattering bang. it was so loud you didn't even hear the phone hit the ground after.)";
        }
        if (dialogueTracker == 1005)
        {
            diaTimer += Time.deltaTime * 1f;
            increaseTrackernumber = false;
            GameManager.instance.scenarioTwoFailed = true;
            GameManager.instance.scenarioOver = true;
        }

        if (diaTimer >= diaTimerMax)
        {
            if (!increaseTrackernumber)
            {
                return;
            }
            else
            {
                diaTimer = 0f;
                dialogueTracker += 1;

            }
        }
    }
}
