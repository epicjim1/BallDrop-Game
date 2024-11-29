using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public int starNum;
    StarCount counter;
    Button button;
    public GameObject lockSprite;

    void Start()
    {
        counter = GameObject.Find("StarCount").GetComponent<StarCount>();
        button = gameObject.GetComponent<Button>();
    }

    void Update()
    {
        if (button.interactable == false)
        {
            lockSprite.SetActive(true);
        }
        else
        {
            lockSprite.SetActive(false);
        }

        if (starNum > counter.starCounter)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
