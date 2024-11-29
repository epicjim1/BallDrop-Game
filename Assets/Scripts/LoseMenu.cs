using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseMenu : MonoBehaviour
{
    public SceneFader fader;
    RetryCount counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.Find("RetryCounter").GetComponent<RetryCount>();
        counter.UI = GameObject.Find("RetryNum");
    }

    // Update is called once per frame
    void Update()
    {
        //counter.UI.GetComponent<TMP_Text>().text = counter.retryNum.ToString();
    }

    public void Menu()
    {
        fader.FadeTo("MainMenu");
    }

    public void Retry()
    {
        counter.addRetry();
        counter.previousLvl();
        fader.FadeTo(SceneManager.GetActiveScene().name);
    }
}
