using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int starNum = 0;
    AudioSource pickup;

    void Awake()
    {
        if (PlayerPrefs.GetString("collectables." + gameObject.name, "false") == "true")
        {
            GameObject.Destroy(gameObject);
        }
    }

    void Start()
    {
        pickup = GetComponent<AudioSource>();
        //PlayerPrefs.GetInt("GotStar", starNum);

        /*if (PlayerPrefs.GetInt("GotStar") != starNum)
        {
            Destroy(gameObject);
        }*/
    }

    void Update()
    {
        //Debug.Log("Got star number: " + PlayerPrefs.GetInt("GotStar"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            /*if (PlayerPrefs.GetInt("GotStar") == starNum)
            {
                pickup.Play();
                //PlayerPrefs.SetInt("StarCount", 30);
                PlayerPrefs.SetInt("StarCount", PlayerPrefs.GetInt("StarCount") + 1);
                //Debug.Log("star + 1");
                PlayerPrefs.SetInt("GotStar", PlayerPrefs.GetInt("GotStar") + 1);
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 1f);
            }*/
            Collect();
        }
    }

    void Collect()
    {
        PlayerPrefs.SetString("collectables." + gameObject.name, "true");
        pickup.Play();
        PlayerPrefs.SetInt("StarCount", PlayerPrefs.GetInt("StarCount") + 1);
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }
}
