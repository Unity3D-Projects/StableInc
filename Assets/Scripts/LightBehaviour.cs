using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBehaviour : MonoBehaviour
{
    public int slot;
    public bool blinking = false;
    public bool activeLight = true;
    public enum lightColors
    {
        RED,
        GREEN,
        BLUE,
        YELLOW
    }
    public PanelObject.panelColor lightColor;

    public Sprite[] redSprites;
    public Sprite[] greenSprites;
    public Sprite[] blueSprites;
    public Sprite[] yellowSprites;
    public Sprite offSprite;

    public Image dithering;
    public Image lightGraphic;

    public float blinkInterval;
    private float timer;
    private bool blinkOn = false;

    public GameObject colorBlindObj;
    public Text colorBlindText;

    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeLight)
        {
            if(SettingsMenu.settings.colorBlindSwtich.currentState == Condition.stateOfCond.ON)
            {
                colorBlindObj.SetActive(true);
                colorBlindText.text = lightColor.ToString();
            }
            else
            {
                colorBlindObj.SetActive(false);
            }
            
            if (blinking)
            {
                if(Time.time > timer)
                {
                    if (blinkOn)
                    {
                        TurnOffLight();
                        blinkOn = false;
                        timer = Time.time + blinkInterval;
                    }
                    else if (!blinkOn)
                    {
                        TurnOnLight();
                        blinkOn = true;
                        timer = Time.time + blinkInterval;
                    }
                }
            }
            else
            {
                TurnOnLight();
            }
        }
        else
        {
            colorBlindObj.SetActive(false);
            TurnOffLight();
        }
    }


    void TurnOnLight()
    {
        dithering.gameObject.SetActive(true);
        if (lightColor == PanelObject.panelColor.Red)
        {
            lightGraphic.sprite = redSprites[0];
            dithering.sprite = redSprites[1];
        }
        else if (lightColor == PanelObject.panelColor.Green)
        {
            lightGraphic.sprite = greenSprites[0];
            dithering.sprite = greenSprites[1];
        }
        else if (lightColor == PanelObject.panelColor.Blue)
        {
            lightGraphic.sprite = blueSprites[0];
            dithering.sprite = blueSprites[1];
        }
        else if (lightColor == PanelObject.panelColor.Yellow)
        {
            lightGraphic.sprite = yellowSprites[0];
            dithering.sprite = yellowSprites[1];
        }
    }
    void TurnOffLight()
    {
        lightGraphic.sprite = offSprite;
        dithering.gameObject.SetActive(false);
        blinkOn = false;
    }
}
