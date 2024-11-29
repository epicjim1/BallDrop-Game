using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public SceneFader fader;
    public float seconds = 6;

    void Start()
    {
        StartCoroutine(Fade()); 
    }

    void Update()
    {
        
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(seconds);
        fader.FadeTo("MainMenu");
    }
}
