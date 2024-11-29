using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private static MusicClass playerInstance;

    private AudioSource _audioSource;

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

        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }
}
