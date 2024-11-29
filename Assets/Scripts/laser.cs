using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public GameObject loseMenu;
    public GameObject circle;
    public GameObject button;
    Unlocker buttonScript;
    public bool canTurnOff = true;

    Material mat;
    bool isDissolving;
    float fade = 1f;
    float speed = 2f;

    void Start()
    {
        mat = circle.GetComponent<SpriteRenderer>().material;
        if(canTurnOff)
        {
            buttonScript = button.GetComponent<Unlocker>();
        }
    }

    void Update()
    {
        if (canTurnOff)
        {
            if (buttonScript.turnedOn)
            {
                gameObject.SetActive(false);
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }*/

        if (isDissolving)
        {
            fade -= Time.deltaTime * speed;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            mat.SetFloat("_Fade", fade);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            isDissolving = true;
            Destroy(GameObject.FindGameObjectWithTag("Circle").GetComponent<CircleCollider2D>());
            Destroy(GameObject.FindGameObjectWithTag("Circle").GetComponent<TrailRenderer>());
            loseMenu.SetActive(true);
            Destroy(circle, 2.5f);
        }
    }
}
