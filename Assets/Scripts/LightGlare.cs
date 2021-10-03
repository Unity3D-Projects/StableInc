using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightGlare : MonoBehaviour
{
    public Color fullColor;
    public Color nullColor;

    public bool lightOn;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightOn)
        {
            float sinWave = 0.5f + Mathf.Sin((Time.time * 2) % 90) / 90 * 50;
            Debug.Log(sinWave);
            image.GetComponent<Image>().color = Color.Lerp(nullColor, fullColor, sinWave);
            image.enabled = true;
        }
        else if (!lightOn)
        {
            image.enabled = false;
        }
    }
}
