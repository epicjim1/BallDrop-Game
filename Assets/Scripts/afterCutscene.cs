using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class afterCutscene : MonoBehaviour
{
    public GameObject videoPlayer;
    public GameObject Animation;
    public int seconds;
    public bool skip;
    public bool restart;

    void Start()
    {
        StartCoroutine(CoFunc());
        //videoPlayer.SetActive(true);
    }

    void Update()
    {
        if (skip == true)
        {
            if (Input.GetKeyDown("e"))
            {
                var lvl2 = Animation.GetComponent<levelChanger>();
                lvl2.fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator CoFunc()
    {
        yield return new WaitForSeconds(seconds);
        var lvl2 = Animation.GetComponent<levelChanger>();

        if (restart == true)
        {
            lvl2.fadeToLevel(0);
        }
        else
        {
            lvl2.fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
