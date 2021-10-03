using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour
{
    public enum countOfCond
    {
        ALL,
        ANY,
        ONE,
        TWO,
        THREE,
        THREEPLUS,
        FOUR,
        FIVE,
        NONE
    }
    public enum typeOfCond
    {
        ERROR_LIGHT,
        BUTTON,
        SWITCH,
        KNOB,
        CRANK
    } 

    public enum colorOfCond
    {
        RED,
        BLUE,
        YELLOW,
        GREEN
    }

    [Header("If there's:")]
    public countOfCond conditionCount;
    public PanelObject.panelColor conditionColor;
    public typeOfCond conditionObject;

    [Header("For lights:")]
    public int slot;
    public bool isBlinking;

    public enum stateOfCond
    {
        OFF,
        ON,
        POWER,
        HYDRO
    }

    [Header("Then check if:")]
    public countOfCond checkCount;
    public PanelObject.panelColor checkColor;
    public typeOfCond checkObject;
    [Header("are set to:")]
    public stateOfCond checkState;
    [Header("or")]
    public int turns;

    [Header("Output")]
    public bool satisfied = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
