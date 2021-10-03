using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelObject : MonoBehaviour
{
    public GameObject subtext;

    public enum panelType
    {
        Button,
        Switch,
        Knob,
        Crank
    }
    public panelType thisType;

    public enum panelColor
    {
        Red,
        Blue,
        Yellow,
        Green,
        Any
    }
    public panelColor thisColor;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
