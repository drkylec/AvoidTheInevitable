using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject contentWarningPanel;

    public Transform playTransform;

    public enum Scenario { One, Two, Three, Four, Five };
    public Scenario scenario = Scenario.One;

    public GameObject scenarioOne;
    public GameObject scenarioTwo;
    public GameObject scenarioThree;
    public GameObject scenarioFour;
    public GameObject scenarioFive;

    public bool phonepickedUp;
    public bool phoneHangUp;

    public int btnPressed = 0;
    public float dispatchtimer = 0f;
    public float dispatchtimerMax = 120f;
    public bool startDispatch = false;
    public bool dispatchArrived = false;

    public int remainedQuiet = 0;

    public bool scenarioOneFailed;
    public bool scenarioTwoFailed;
    public bool scenarioThreeFailed;
    public bool scenarioOver;
    public bool senOneBadge;
    public bool senTwoBadge;
    public bool senThreeBadge;
    public bool scenarioOneComplete;
    public bool scenarioTwoComplete;
    public bool scenarioThreeComplete;

    public Image comp1;
    public Image comp2;
    public Image comp3;
    public Sprite comp1Empty;
    public Sprite comp2Empty;
    public Sprite comp3Empty;
    public Sprite comp1Fail;
    public Sprite comp2Fail;
    public Sprite comp3Fail;
    public Sprite comp1Suc;
    public Sprite comp2Suc;
    public Sprite comp3Suc;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        scenarioOne.SetActive(false);
        scenarioTwo.SetActive(false);
        scenarioThree.SetActive(false);
        scenarioFour.SetActive(false);
        scenarioFive.SetActive(false);

        Time.timeScale = 0f;

        MoveDown();
    }

    private void Update()
    {
        ScenarioSkipper();//used to debug
        ScenarioCompletionStats();
        DispatchArrived();

        if (scenario == Scenario.One)
        {
            scenarioOne.SetActive(true);
            scenarioTwo.SetActive(false);
            scenarioThree.SetActive(false);
            scenarioFour.SetActive(false);
            scenarioFive.SetActive(false);
        }
        else if (scenario == Scenario.Two)
        {
            scenarioOne.SetActive(false);
            scenarioTwo.SetActive(true);
            scenarioThree.SetActive(false);
            scenarioFour.SetActive(false);
            scenarioFive.SetActive(false);
        }
        else if (scenario == Scenario.Three)
        {
            scenarioOne.SetActive(false);
            scenarioTwo.SetActive(false);
            scenarioThree.SetActive(true);
            scenarioFour.SetActive(false);
            scenarioFive.SetActive(false);
        }
        else if (scenario == Scenario.Four)
        {
            scenarioOne.SetActive(false);
            scenarioTwo.SetActive(false);
            scenarioThree.SetActive(false);
            scenarioFour.SetActive(true);
            scenarioFive.SetActive(false);
        }
        else if (scenario == Scenario.Five)
        {
            scenarioOne.SetActive(false);
            scenarioTwo.SetActive(false);
            scenarioThree.SetActive(false);
            scenarioFour.SetActive(false);
            scenarioFive.SetActive(true);
        }
        else
        {

        }

        if (btnPressed == 4)
        {
            startDispatch = true;
        }

        if (startDispatch)
        {
            dispatchtimer += Time.deltaTime * 1f;
        }

        if (phoneHangUp)
        {
            scenarioOver = true;

            if (scenario == Scenario.One)
            {
                scenarioOneFailed = true;
                scenarioOneComplete = true;
                phoneHangUp = false;
            }
            if (scenario == Scenario.Two)
            {
                scenarioTwoFailed = true;
                scenarioTwoComplete = true;
                phoneHangUp = false;
            }
            if (scenario == Scenario.Three)
            {
                scenarioThreeFailed = true;
                scenarioThreeComplete = true;
                phoneHangUp = false;
            }
        }

        if (scenarioOver)
        {
            if (scenario == Scenario.One)
            {
                scenarioOneComplete = true;
                ResetStats();
                scenario = Scenario.Two;
                return;
            }
            if (scenario == Scenario.Two)
            {
                scenarioTwoComplete = true;
                ResetStats();
                scenario = Scenario.Three;
                return;
            }
            if (scenario == Scenario.Three)
            {
                scenarioThreeComplete = true;
                ResetStats();
                SceneManager.LoadScene(2);
                return;
            }
            if (scenario == Scenario.Four)
            {

            }
            if (scenario == Scenario.Five)
            {

            }
        }
    }

    public void ResetStats()
    {
        phonepickedUp = false;
        phoneHangUp = false;

        btnPressed = 0;
        dispatchtimer = 0f;
        startDispatch = false;
        dispatchArrived = false;

        remainedQuiet = 0;

        scenarioOver = false;
    }

    void ScenarioCompletionStats()
    {
        if (scenarioOneComplete)
        {
            if (!scenarioOneFailed)
            {
                senOneBadge = true;
            }
            else
            {
                senOneBadge = false;
            }

            if (senOneBadge)
            {
                comp1.sprite = comp1Suc;
            }
            else
            {
                comp1.sprite = comp1Fail;
            }
        }
        else
        {
            comp1.sprite = comp1Empty;
        }
        
        if(scenarioTwoComplete)
        {
            if(!scenarioTwoFailed)
            {
                senTwoBadge = true;
            }
            else
            {
                senTwoBadge = false;
            }

            if (senTwoBadge)
            {
                comp2.sprite = comp2Suc;
            }
            else
            {
                comp2.sprite = comp2Fail;
            }
        }
        else
        {
            comp2.sprite = comp2Empty;
        }

        if (scenarioThreeComplete)
        {
            if (!scenarioThreeFailed)
            {
                senThreeBadge = true;
            }
            else
            {
                senThreeBadge = false;
            }

            if (senTwoBadge)
            {
                comp3.sprite = comp3Suc;
            }
            else
            {
                comp3.sprite = comp3Fail;
            }
        }
        else
        {
            comp3.sprite = comp3Empty;
        }
    }

    public void MoveDown()
    {
        playTransform.localPosition = new Vector2(0, -200);
    }

    public void MoveUp()
    {
        playTransform.localPosition = new Vector2(0, 0);
    }

    void ScenarioSkipper()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            scenario = Scenario.One;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            scenario = Scenario.Two;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            scenario = Scenario.Three;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            scenario = Scenario.Four;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            scenario = Scenario.Five;
        }
    }

    void DispatchArrived()
    {
        if(dispatchtimer >= dispatchtimerMax)
        {
            dispatchArrived = true;
            if(scenario == Scenario.One)
            {
                scenarioOneFailed = false;
                scenarioOneComplete = true;
            }
            if(scenario == Scenario.Two)
            {
                scenarioTwoFailed = false;
                scenarioTwoComplete = true;
            }
            if(scenario == Scenario.Three)
            {
                scenarioThreeFailed = false;
                scenarioThreeComplete = true;
            }
        }
    }
}
