using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float initialTime;
    public float timeBetweenLevels;

    [Header("Light One")]
    public bool lightOneEnabled = true;
    public PanelObject.panelColor lightOneColor;
    public bool lightOneisBlinking;
    public float lightOneBlinkSpeed;
    [Header("Light Two")]
    public bool lightTwoEnabled = true;
    public PanelObject.panelColor lightTwoColor;
    public bool lightTwoisBlinking;
    public float lightTwoBlinkSpeed;
    [Header("Light Three")]
    public bool lightThreeEnabled = true;
    public PanelObject.panelColor lightThreeColor;
    public bool lightThreeisBlinking;
    public float lightThreeBlinkSpeed;
    [Header("Light Four")]
    public bool lightFourEnabled = true;
    public PanelObject.panelColor lightFourColor;
    public bool lightFourisBlinking;
    public float lightFourBlinkSpeed;
    [Header("Light Five")]
    public bool lightFiveEnabled = true;
    public PanelObject.panelColor lightFiveColor;
    public bool lightFiveisBlinking;
    public float lightFiveBlinkSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
