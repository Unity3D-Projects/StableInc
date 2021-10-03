using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knob : PanelObject
{
    public enum knobState
    {
        OFF,
        POWER,
        HYDRO
    }
    public Condition.stateOfCond currentState;

    public Sprite offSprite;
    public Sprite powerSprite;
    public Sprite hydroSprite;

    public Image graphics;

    public AudioClip knobSound;

    private void Start()
    {
        if (currentState == Condition.stateOfCond.OFF)
        {
            graphics.sprite = offSprite;
        }
        else if (currentState == Condition.stateOfCond.POWER)
        {
            graphics.sprite = powerSprite;
        }
        else if (currentState == Condition.stateOfCond.HYDRO)
        {
            graphics.sprite = hydroSprite;
        }
    }

    public void OnClick()
    {
        AudioManager.player.PlaySound(knobSound);
        if (currentState == Condition.stateOfCond.OFF)
        {
            currentState = Condition.stateOfCond.POWER;
            graphics.sprite = powerSprite;
        }
        else if (currentState == Condition.stateOfCond.POWER)
        {
            currentState = Condition.stateOfCond.HYDRO;
            graphics.sprite = hydroSprite;
        }
        else if (currentState == Condition.stateOfCond.HYDRO)
        {
            currentState = Condition.stateOfCond.OFF;
            graphics.sprite = offSprite;
        }
    }
}
