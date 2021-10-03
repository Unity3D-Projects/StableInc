using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioSource alarmSource;

    public static AudioManager player;

    private float playTimer = 0;

    public float startingAlarmSpeed;
    public float alarmSpeedSpeedUpFactor;
    private float currentAlarmSpeed;

    private float alarmTimer = 0;
    public AudioClip alarmSound;

    public AudioClip buttonSound;

    public AudioClip nextLevelSound;

    // Start is called before the first frame update
    void Start()
    {
        player = this;
        currentAlarmSpeed = startingAlarmSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        source.pitch = Random.Range(0.9f, 1.1f);
        source.PlayOneShot(clip);
    }

    public void PlayOneAtATime(AudioClip clip)
    {
        if(Time.time > playTimer)
        {
            playTimer = Time.time + clip.length;
            PlaySound(clip);
        }
    }

    public void PlayAlarm()
    {
        if (Time.time > alarmTimer)
        {
            if(alarmSound.length > currentAlarmSpeed)
            {
                alarmTimer = Time.time + alarmSound.length;
            }
            else
            {
                alarmTimer = Time.time + currentAlarmSpeed;
            }
            alarmSource.PlayOneShot(alarmSound);
            currentAlarmSpeed -= Time.deltaTime * alarmSpeedSpeedUpFactor;
            Debug.Log(currentAlarmSpeed);
        }
    }

    public void ResetAlarm()
    {
        currentAlarmSpeed = startingAlarmSpeed;
    }


}
