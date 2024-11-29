using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformShooter : MonoBehaviour
{
    public GameObject button;
    UserClick buttonScript;
    public bool playerControlled = true;
    public bool isFlipped = false;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject platform;
    public Transform firePoint;

    void Start()
    {
        if (playerControlled)
        {
            buttonScript = button.GetComponent<UserClick>();
        }
    }

    void Update()
    {
        if (playerControlled)
        {
            if (buttonScript.buttonPressed)
            {
                shoot();
            }
        }
        else
        {
            shoot();
        }
    }

    void OnMouseDown()
    {
        /*Debug.Log("mouseclicked2");
        if (playerControlled)
        {
            Debug.Log("mouseclicked");
            //shoot();
        }*/
    }

    public void shoot()
    {
        if (timeBetweenShots <= 0)
        {
            GameObject clone = Instantiate(platform, firePoint.position, firePoint.rotation);

            if (isFlipped)
            {
                clone.GetComponent<SpriteRenderer>().flipX = true;
            }

            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
