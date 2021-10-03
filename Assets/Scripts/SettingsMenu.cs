using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{
    public Crank masterVolume;
    public Crank bgmVolume;
    public Crank sfxVolume;
    public Crank alarmVolume;

    public Switch colorBlindSwtich;

    public AudioMixer mixer;

    bool isOpen = false;

    float settingsTimer = 0;

    bool colorBlind = false;

    public static SettingsMenu settings;

    // Start is called before the first frame update
    void Start()
    {
        settings = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Settings") > 0.5f && !isOpen && Time.time > settingsTimer)
        {
            OnEnter();
            settingsTimer = Time.time + 1.1f;
        }
        else if (Input.GetAxisRaw("Settings") > 0.5f && isOpen && Time.time > settingsTimer)
        {
            OnExit();
            settingsTimer = Time.time + 1.1f;
        }

        mixer.SetFloat("alarmVolume", 10 * alarmVolume.currentNumber - 40);
        mixer.SetFloat("bgmVolume", 10 * bgmVolume.currentNumber - 40);
        mixer.SetFloat("panelVolume", 10 * sfxVolume.currentNumber - 40);
        mixer.SetFloat("masterVolume", 10 * masterVolume.currentNumber - 40);

        if (colorBlindSwtich.currentState == Condition.stateOfCond.ON)
        {
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Button"))
            {
                currentObject.GetComponent<PanelButton>().subtext.SetActive(true);
            }
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Switch"))
            {
                currentObject.GetComponent<Switch>().subtext.SetActive(true);
            }
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Crank"))
            {
                currentObject.GetComponent<Crank>().subtext.SetActive(true);
            }
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Knob"))
            {
                currentObject.GetComponent<Knob>().subtext.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Button"))
            {
                currentObject.GetComponent<PanelButton>().subtext.SetActive(false);
            }
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Switch"))
            {
                currentObject.GetComponent<Switch>().subtext.SetActive(false);
            }
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Crank"))
            {
                currentObject.GetComponent<Crank>().subtext.SetActive(false);
            }
            foreach (GameObject currentObject in GameObject.FindGameObjectsWithTag("Knob"))
            {
                currentObject.GetComponent<Knob>().subtext.SetActive(false);
            }
        }
    }

    public void OnEnter()
    {
        GetComponent<DOTweenAnimation>().DOPlayForward();
        isOpen = true;
    }

    public void OnExit()
    {
        GetComponent<DOTweenAnimation>().DOPlayBackwards();
        isOpen = false;
    }

}
