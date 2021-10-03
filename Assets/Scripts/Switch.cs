using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : PanelObject
{
    public enum switchState
    {
        ON,
        OFF
    }
    public Condition.stateOfCond currentState;

    public Sprite offSprite;
    public Sprite onSprite;

    public Image graphics;

    public Sprite lightOff;
    public Sprite lightOn;

    public Image indicatorLight;

    public AudioClip switchSoundOn;
    public AudioClip switchSoundOff;

    // Start is called before the first frame update
    void Start()
    {

        if (currentState == Condition.stateOfCond.OFF)
        {
            graphics.sprite = offSprite;
            indicatorLight.sprite = lightOff;
        }
        else if (currentState == Condition.stateOfCond.ON)
        {
            graphics.sprite = onSprite;
            indicatorLight.sprite = lightOn;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        if (currentState == Condition.stateOfCond.OFF)
        {
            AudioManager.player.PlaySound(switchSoundOn);
            currentState = Condition.stateOfCond.ON;
            graphics.sprite = onSprite;
            indicatorLight.sprite = lightOn;
        }
        else if (currentState == Condition.stateOfCond.ON)
        {
            AudioManager.player.PlaySound(switchSoundOff);
            currentState = Condition.stateOfCond.OFF;
            graphics.sprite = offSprite;
            indicatorLight.sprite = lightOff;
        }
    }
}
