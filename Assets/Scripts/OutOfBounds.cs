using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    public GameObject loseMenu;
    public GameObject target;
    public GameObject circle;
    //AudioSource lose;

    public bool isInner;

    void Start()
    {
        //lose = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isInner)
        {
            if (collision.tag == "Circle")
            {
                //lose.Play();
                loseMenu.SetActive(true);
                Destroy(circle);
            }
        }
        else
        {
            if (collision.tag == "Target")
            {
                target.transform.position = new Vector2(0, 0);
            }
        }
    }
}
