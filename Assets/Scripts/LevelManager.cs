using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject winText;
    public Stage thisStage;
    public StableIndicator stableIndicator;

    public Condition[] conditions;

    public Level[] levels;
    public int currentLevel = 0;
    public float initialTime;
    public float timeBetweenLevels;
    public float timerOffset = 0;

    private int matchCount = 0;
    private int checkCount = 0;

    private PanelButton currentPressedButton;

    private bool anyFalse = true;

    private bool levelActive = false;

    private void LateUpdate()
    {
        currentPressedButton = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel == levels.Length)
        {
            Debug.Log("Finished!");
            NextLevel();
        }

        //Light Stuff
        if ((Time.time > initialTime + timerOffset && currentLevel == 0) || (Time.time > (timeBetweenLevels + timerOffset) && levelActive == false))
        {
            stableIndicator.stable = false;
            levelActive = true;
            for (int currentSlot = 1; currentSlot < 5; currentSlot++)
            {
                foreach (GameObject currentLight in GameObject.FindGameObjectsWithTag("Light"))
                {
                    LightBehaviour thisLight = currentLight.GetComponent<LightBehaviour>();
                    if (thisLight != null)
                    {
                        if (thisLight.slot == currentSlot)
                        {
                            CheckLights(thisLight);
                        }
                    }

                }
            }
        }
        else if (!levelActive)
        {
            stableIndicator.stable = true;
            foreach (Condition currentCond in conditions)
            {
                currentCond.satisfied = false;
            }
        }


        //Condition Checking

        if (levelActive)
        {
            //winText.SetActive(false);
            anyFalse = false;
            foreach (Condition currentCond in conditions)
            {
                matchCount = 0;
                if (CheckConditionRequirements(currentCond))
                {
                    matchCount = 0;
                    checkCount = 0;
                    if (CheckConditionParameters(currentCond))
                    {
                        currentCond.satisfied = true;
                    }
                    else
                    {
                        currentCond.satisfied = false;
                        anyFalse = true;
                    }
                }
                else
                {
                    currentCond.satisfied = true;
                }
            }
        }
        

        if(!anyFalse)
        {
            //winText.SetActive(true);
            currentLevel++;
            levelActive = false;
            timerOffset = Time.time;
            anyFalse = true;
            foreach (GameObject currentLight in GameObject.FindGameObjectsWithTag("Light"))
            {
                LightBehaviour thisLight = currentLight.GetComponent<LightBehaviour>();
                if (thisLight != null)
                {
                    thisLight.activeLight = false;
                }

            }
        }

        bool CheckConditionRequirements(Condition currentCond)
        {
            if (currentCond.conditionObject == Condition.typeOfCond.ERROR_LIGHT)
            {
                GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
                foreach (GameObject currentLight in lights)
                {
                    LightBehaviour thisLight = currentLight.GetComponent<LightBehaviour>();
                    if ((thisLight.slot == currentCond.slot) || currentCond.slot == 0)
                    {
                        if ((CheckColor(thisLight.lightColor, currentCond.conditionColor) && thisLight.activeLight) 
                            || currentCond.conditionColor == PanelObject.panelColor.Any)
                        {
                            if (thisLight.activeLight)
                            {
                                if ((thisLight.blinking && currentCond.isBlinking) || !currentCond.isBlinking)
                                {
                                    matchCount++;
                                }
                            }

                        }
                    }
                }
            }
            else if (currentCond.conditionObject == Condition.typeOfCond.BUTTON)
            {
                GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
                foreach (GameObject currentButton in buttons)
                {
                    PanelButton thisButton = currentButton.GetComponent<PanelButton>();
                    if (CheckColor(thisButton.thisColor, currentCond.conditionColor))
                    {
                        matchCount++;
                    }
                }
            }
            else if (currentCond.conditionObject == Condition.typeOfCond.SWITCH)
            {
                GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");

                foreach (GameObject currentSwitch in switches)
                {
                    Switch thisSwitch = currentSwitch.GetComponent<Switch>();
                    if (CheckColor(thisSwitch.thisColor, currentCond.conditionColor))
                    {
                        matchCount++;
                    }
                }
            }
            else if (currentCond.conditionObject == Condition.typeOfCond.KNOB)
            {
                GameObject[] knobs = GameObject.FindGameObjectsWithTag("Knob");

                foreach (GameObject currentKnob in knobs)
                {
                    Knob thisKnob = currentKnob.GetComponent<Knob>();
                    if (CheckColor(thisKnob.thisColor, currentCond.conditionColor))
                    {
                        matchCount++;
                    }
                }
            }
            else if (currentCond.conditionObject == Condition.typeOfCond.CRANK)
            {
                GameObject[] cranks = GameObject.FindGameObjectsWithTag("Crank");

                foreach (GameObject currentCrank in cranks)
                {
                    Crank thisCrank = currentCrank.GetComponent<Crank>();
                    if (CheckColor(thisCrank.thisColor, currentCond.conditionColor))
                    {
                        matchCount++;
                    }
                }
            }

            if (matchCount == 0 && currentCond.conditionCount == Condition.countOfCond.NONE)
            {
                return true;
            }
            else if ((matchCount > 0) && currentCond.conditionCount == Condition.countOfCond.ANY)
            {
                return true;
            }
            else if (matchCount == 1 && currentCond.conditionCount == Condition.countOfCond.ONE)
            {
                return true;
            }
            else if (matchCount == 2 && currentCond.conditionCount == Condition.countOfCond.TWO)
            {
                return true;
            }
            else if (matchCount == 3 && currentCond.conditionCount == Condition.countOfCond.THREE)
            {
                return true;
            }
            else if (matchCount >= 3 && currentCond.conditionCount == Condition.countOfCond.THREEPLUS)
            {
                return true;
            }
            else if (matchCount == 4 && currentCond.conditionCount == Condition.countOfCond.FOUR)
            {
                return true;
            }
            else if (matchCount == 5 && currentCond.conditionCount == Condition.countOfCond.FIVE)
            {
                return true;
            }
            return false;
        }

        bool CheckConditionParameters(Condition currentCond)
        {
            if (currentCond.checkObject == Condition.typeOfCond.SWITCH)
            {
                GameObject[] switches = GameObject.FindGameObjectsWithTag("Switch");
                if(switches == null)
                {
                    return true;
                }
                foreach (GameObject currentSwitch in switches)
                {
                    Switch thisSwitch = currentSwitch.GetComponent<Switch>();
                    if (CheckColor(thisSwitch.thisColor, currentCond.checkColor))
                    {
                        matchCount++;
                        if(thisSwitch.currentState == currentCond.checkState)
                        {
                            checkCount++;
                        }
                    }
                }
                if (matchCount == 0)
                {
                    return true;
                }
            }
            else if (currentCond.checkObject == Condition.typeOfCond.KNOB)
            {
                GameObject[] knobs = GameObject.FindGameObjectsWithTag("Knob");
                if (knobs == null)
                {
                    return true;
                }
                foreach (GameObject currentKnob in knobs)
                {
                    Knob thisKnob = currentKnob.GetComponent<Knob>();
                    if (CheckColor(thisKnob.thisColor, currentCond.checkColor))
                    {  
                        matchCount++;
                        if (thisKnob.currentState == currentCond.checkState)
                        {
                            checkCount++;
                        }
                    }
                }
                if (matchCount == 0)
                {
                    return true;
                }
            }
            else if (currentCond.checkObject == Condition.typeOfCond.CRANK)
            {
                GameObject[] cranks = GameObject.FindGameObjectsWithTag("Crank");
                if (cranks == null)
                {
                    return true;
                }
                foreach (GameObject currentCrank in cranks)
                {
                    Crank thisCrank = currentCrank.GetComponent<Crank>();
                    if (CheckColor(thisCrank.thisColor, currentCond.checkColor))
                    {
                        matchCount++;
                        if (thisCrank.currentNumber == currentCond.turns)
                        {
                            checkCount++;
                        }
                    }
                }
                if (matchCount == 0)
                {
                    return true;
                }
            }
            else if (currentCond.checkObject == Condition.typeOfCond.BUTTON)
            {
                if(currentPressedButton != null)
                {
                    if (CheckColor(currentPressedButton.thisColor, currentCond.checkColor))
                    {
                        matchCount++;
                        checkCount++;
                    }
                    currentPressedButton = null;
                } 
            }

            
            if (checkCount == 0 && currentCond.checkCount == Condition.countOfCond.NONE)
            {
                return true;
            }
            else if ((checkCount > 0) && currentCond.checkCount == Condition.countOfCond.ANY)
            {
                return true;
            }
            else if (checkCount == 1 && currentCond.checkCount == Condition.countOfCond.ONE)
            {
                return true;
            }
            else if (checkCount == matchCount && currentCond.checkCount == Condition.countOfCond.ALL)
            {
                return true;
            }

            return false;
        }

        bool CheckColor(PanelObject.panelColor checkColor, PanelObject.panelColor targetColor)
        {
            if(checkColor == targetColor)
            {
                return true;
            }

            return false;
        }

        

    }

    public void OnButtonClick(PanelButton newButton)
    {
        currentPressedButton = newButton;
    }

    void CheckLights(LightBehaviour thisLight)
    {
        if (thisLight.slot == 1)
        {
            thisLight.activeLight = levels[currentLevel].lightOneEnabled;
            thisLight.lightColor = levels[currentLevel].lightOneColor;
            thisLight.blinking = levels[currentLevel].lightOneisBlinking;
            thisLight.blinkInterval = levels[currentLevel].lightOneBlinkSpeed;
        }
        else if (thisLight.slot == 2)
        {
            thisLight.activeLight = levels[currentLevel].lightTwoEnabled;
            thisLight.lightColor = levels[currentLevel].lightTwoColor;
            thisLight.blinking = levels[currentLevel].lightTwoisBlinking;
            thisLight.blinkInterval = levels[currentLevel].lightTwoBlinkSpeed;
        }
        else if (thisLight.slot == 3)
        {
            thisLight.activeLight = levels[currentLevel].lightThreeEnabled;
            thisLight.lightColor = levels[currentLevel].lightThreeColor;
            thisLight.blinking = levels[currentLevel].lightThreeisBlinking;
            thisLight.blinkInterval = levels[currentLevel].lightThreeBlinkSpeed;
        }
        else if (thisLight.slot == 4)
        {
            thisLight.activeLight = levels[currentLevel].lightFourEnabled;
            thisLight.lightColor = levels[currentLevel].lightFourColor;
            thisLight.blinking = levels[currentLevel].lightFourisBlinking;
            thisLight.blinkInterval = levels[currentLevel].lightFourBlinkSpeed;
        }
        else if (thisLight.slot == 5)
        {
            thisLight.activeLight = levels[currentLevel].lightFiveEnabled;
            thisLight.lightColor = levels[currentLevel].lightFiveColor;
            thisLight.blinking = levels[currentLevel].lightFiveisBlinking;
            thisLight.blinkInterval = levels[currentLevel].lightFiveBlinkSpeed;
        }
    }

    void NextLevel()
    {
        stableIndicator.stable = true;
        foreach (GameObject currentLight in GameObject.FindGameObjectsWithTag("Light"))
        {
            LightBehaviour thisLight = currentLight.GetComponent<LightBehaviour>();
            if (thisLight != null)
            {
                thisLight.activeLight = false;
            }

        }
        thisStage.complete = true;
    }
}
