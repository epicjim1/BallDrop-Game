using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StarCount : MonoBehaviour
{
    private static StarCount playerInstance;

    private TMP_Text UI;
    [HideInInspector]
    public GameObject shop;
    public int starCounter;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        starCounter = PlayerPrefs.GetInt("StarCount", 0);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            starCounter += 1;
        }*/

        starCounter = PlayerPrefs.GetInt("StarCount");

        if (SceneManager.GetActiveScene().name == "MainMenu" && shop != null)
        {
            if (UI == null)
            {
                UI = GameObject.Find("Count").GetComponent<TMP_Text>();
            }
            UI.text = starCounter.ToString();
        }
    }

    /*public void findShopMenu ()
    {
        shop = GameObject.Find("ShopMenu");
    }*/
}
