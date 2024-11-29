using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float turnSpeed = 50;
    float orgTurnSpeed;
    float negTurnSpeed;

    SpriteRenderer sprite;

    public GameObject buttonSprite;
    UserClick button;
    public bool canSwitch = false;

    void Start()
    {
        orgTurnSpeed = turnSpeed;
        negTurnSpeed = -turnSpeed;
        sprite = GetComponent<SpriteRenderer>();
        if (canSwitch)
        {
            button = buttonSprite.GetComponent<UserClick>();
        }
    }

    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * turnSpeed);
    }

    private void Update()
    {
        if (canSwitch)
        {
            if (button.buttonPressed == true)
            {
                turnSpeed = negTurnSpeed;
                if (sprite.flipX != true)
                {
                    sprite.flipX = true;
                }
            }
            else
            {
                turnSpeed = orgTurnSpeed;
                if (sprite.flipX == true)
                {
                    sprite.flipX = false;
                }
            }
        }
    }
}
