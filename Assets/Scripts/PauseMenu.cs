using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public SceneFader fader;

    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject skipMenu;

    RetryCount counter;

    void Start()
    {
        counter = GameObject.Find("RetryCounter").GetComponent<RetryCount>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!winMenu.activeInHierarchy && !loseMenu.activeInHierarchy && !skipMenu.activeInHierarchy)
            {
                Toggle();
            }
        }

        /*if (counter.retryNum >= 3)
        {
            Toggle();
        }*/
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        counter.addRetry();
        counter.previousLvl();
        Toggle();
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Toggle();
        fader.FadeTo("MainMenu");
    }
}
