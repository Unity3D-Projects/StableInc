using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StableIndicator : MonoBehaviour
{
    public bool stable;

    public Sprite stableSprite;
    public Sprite unstableSprite;

    public Image image;

    public LightGlare glare;

    // Update is called once per frame
    void Update()
    {
        if (stable)
        {
            AudioManager.player.ResetAlarm();
            glare.lightOn = false;
            image.sprite = stableSprite;
        }
        else if (!stable)
        {
            AudioManager.player.PlayAlarm();
            glare.lightOn = true;
            image.sprite = unstableSprite;
        }
    }
}
