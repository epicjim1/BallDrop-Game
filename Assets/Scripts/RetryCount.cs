using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RetryCount : MonoBehaviour
{
    private static RetryCount playerInstance;

    public int retryNum;
    public string lastLvlName;
    public string currentLvlName;
    public bool isLastlvl = false;

    public GameObject UI;

    public InterstitialAdsButton failAd;
    public SkipMenu skipMenu;
    //PauseMenu pause;
    bool hasShownSkipScreen = false;

    void Start()
    {
        //pause = GameObject.Find("OverlayCanvas").GetComponent<PauseMenu>();
        skipMenu = GameObject.Find("OverlayCanvas").GetComponent<SkipMenu>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        currentLvlName = SceneManager.GetActiveScene().name;
        if (currentLvlName != lastLvlName)
        {
            retryNum = 0;
        }

        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            if (skipMenu == null)
            {
                Debug.Log("finding skipmenu");
                skipMenu = GameObject.Find("OverlayCanvas").GetComponent<SkipMenu>();
            }
        }

        if (retryNum == 3)
        {
            //Debug.Log("display ad");
            //retryNum = 0;
            //pause.Toggle();
            retryNum += 1;
            failAd.ShowAd();
        }
        else if (retryNum == 6)
        {
            if (!hasShownSkipScreen && currentLvlName != "lvl30")
            {
                Debug.Log("show reward ad");
                StartCoroutine(skip());
                hasShownSkipScreen = true;
            }
        }
        else if (retryNum == 7)
        {
            failAd.ShowAd();
            hasShownSkipScreen = false;
            retryNum = 0;
        }
    }

    IEnumerator skip()
    {
        yield return new WaitForSeconds(.7f);
        skipMenu.Toggle();

    }

    public void previousLvl ()
    {
        lastLvlName = SceneManager.GetActiveScene().name;
    }

    public void addRetry ()
    {
        retryNum += 1;
    }
}
