using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject circle;
    public GameObject WinMenu;

    public int levelToUnlock = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            //Debug.Log("You win, next level");
            if (PlayerPrefs.GetInt("levelReached") < levelToUnlock)
            {
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }
            WinMenu.SetActive(true);
            Destroy(circle, 0.2f);
        }
    }
}
