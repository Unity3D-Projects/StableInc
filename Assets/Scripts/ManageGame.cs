using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManageGame : MonoBehaviour
{
    public GameObject levelCompleteScreen;

    public GameObject[] levels;
    public int currentLevel = 0;

    public GameObject mainMenu;

    public bool play = false;

    public SettingsMenu settings;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (levels[currentLevel].GetComponent<Stage>().complete)
            {
                currentLevel++;
                AudioManager.player.PlaySound(AudioManager.player.nextLevelSound);
                StartCoroutine(NextLevel());
            }
        }
        
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        levelCompleteScreen.GetComponent<DOTweenAnimation>().DOPlay();
        yield return new WaitForSeconds(1.25f);
        levels[currentLevel-1].SetActive(false);
        levels[currentLevel].SetActive(true);
        if(levels[currentLevel].GetComponent<Stage>().levelManager != null)
            levels[currentLevel].GetComponent<Stage>().levelManager.timerOffset = Time.time;
        yield return new WaitForSeconds(2);
        levelCompleteScreen.GetComponent<DOTweenAnimation>().DORewind();
    }

    public void OnPlay()
    {
        AudioManager.player.PlaySound(AudioManager.player.buttonSound);
        play = true;
        levels[currentLevel].SetActive(true);
        if (levels[currentLevel].GetComponent<Stage>().levelManager != null)
            levels[currentLevel].GetComponent<Stage>().levelManager.timerOffset = Time.time;
        //mainMenu.GetComponent<DOTweenAnimation>().DOPlay();
    }

    public void OnOpenSettings()
    {
        
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
