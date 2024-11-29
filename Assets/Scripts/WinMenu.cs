using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public SceneFader fader;
    public string nextLevel = "lvl2";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        fader.FadeTo("MainMenu");
    }

    public void Next()
    {
        fader.FadeTo(nextLevel);
    }
}
