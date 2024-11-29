using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocker : MonoBehaviour
{
    [HideInInspector]
    public bool turnedOn = false;

    AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            myAudio.Play();
            turnedOn = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
