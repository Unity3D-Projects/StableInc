using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Crank : PanelObject
{
    public int currentNumber;

    public Button button;

    public Transform numberWheel;

    public void Update()
    {
        float angle = numberWheel.eulerAngles.z;
        if(angle >= 0 && angle <= 60)
        {
            currentNumber = 1;
        }
        else if (angle > 60 && angle <= 120)
        {
            currentNumber = 2;
        }
        else if (angle > 120 && angle <= 180)
        {
            currentNumber = 3;
        }
        else if (angle > 180 && angle <= 240)
        {
            currentNumber = 4;
        }
        else if (angle > 240 && angle <= 300)
        {
            currentNumber = 5;
        }
        else if (angle > 300 && angle <= 360)
        {
            currentNumber = 6;
        }
    }


    public void OnClick()
    {
        Debug.Log("Clicked");
    }
}
