using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource thisAudio;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Circle"))
        {
            if (GetComponent<AudioSource>() != null)
            {
                if (thisAudio != null)
                {
                    thisAudio.Play();
                }
            }
        }
    }
}
