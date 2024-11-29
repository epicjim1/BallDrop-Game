using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class levelChanger : MonoBehaviour
{
    public Animator animator;

    int levelToLoad;

    void Start()
    {
        
    }

    void Update()
    {
        /*if(Input.GetKeyDown("e"))
        {
            fadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        */
    }

    public void fadeToLevel (int buildIndex)
    {
        levelToLoad = buildIndex;
        animator.SetTrigger("fadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
