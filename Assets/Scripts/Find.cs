using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    GameObject starCount;
    StarCount starCounter;
    GameObject music;

    public bool isShopFind;

    void Start()
    {
        if (isShopFind)
        {
            starCount = GameObject.Find("StarCount");
            starCounter = starCount.GetComponent<StarCount>();
        }
        else
        {
            music = GameObject.FindGameObjectWithTag("Music");
        }
    }

    void Update()
    {
        
    }

    public void findShop ()
    {
        starCounter.shop = GameObject.Find("ShopMenu");
    }

    public void SwitchMusic()
    {
        if (music.GetComponent<AudioSource>().isPlaying)
        {
            music.GetComponent<MusicClass>().StopMusic();
        }
        else
        {
            music.GetComponent<MusicClass>().PlayMusic();
        }
    }
}
