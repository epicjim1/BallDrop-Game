using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserClick : MonoBehaviour
{
    [HideInInspector]
    public bool buttonPressed = false;
    SpriteRenderer sprite;
    AudioSource click;

    public bool isClicker = false;
    public float enableTime = 0.2f;
    bool isDisabling = false;

    void Start()
    {
        click = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isClicker == false)
        {
            if (!buttonPressed)
            {
                click.Play();
                buttonPressed = true;
                sprite.enabled = false;
            }
            else
            {
                click.Play();
                buttonPressed = false;
                sprite.enabled = true;
            }
        }
        else
        {
            if (isDisabling == false)
            {
                isDisabling = true;
                buttonPressed = true;
                StartCoroutine(SpriteDisable());
            }
        }
    }

    public IEnumerator SpriteDisable()
    {
        sprite.enabled = false;
        yield return new WaitForSeconds(enableTime);
        sprite.enabled = true;
        buttonPressed = false;
        isDisabling = false;
    }
}
