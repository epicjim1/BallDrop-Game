using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10f;

    public GameObject[] Cameras;
    bool isSwitching;

    public Joystick joystick;
    public float moveSpeed= 2f;
    public Rigidbody2D rb;
    private Vector2 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        /*if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }*/

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            isSwitching = true;
            if(isSwitching)
            {
                if (Cameras[0].activeInHierarchy)
                {
                    Cameras[1].SetActive(true);
                    Cameras[0].SetActive(false);
                    isSwitching = false;
                }
                else if (!Cameras[0].activeInHierarchy)
                {
                    Cameras[0].SetActive(true);
                    Cameras[1].SetActive(false);
                    isSwitching = false;
                }
            }
        }*/
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    /*public void ActivateCamera(int index)
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (i == index)
            {
                Cameras[i].SetActive(true);
            }
            else
            {
                Cameras[i].SetActive(false);
            }
        }
    }*/
}
