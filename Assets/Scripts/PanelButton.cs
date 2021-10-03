using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButton : PanelObject
{
    public bool pressed = false;

    public AudioClip buttonSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        AudioManager.player.PlaySound(buttonSound);
        LevelManager levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        levelManager.OnButtonClick(this);
    }
}
