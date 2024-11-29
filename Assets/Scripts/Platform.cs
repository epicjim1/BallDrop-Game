using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 2f;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != GameObject.FindGameObjectWithTag("Circle"))
        {
            Destroy(gameObject);
        }
    }
}
