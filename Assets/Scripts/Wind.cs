using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public int moveSpeed = 10;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Object entered trigger");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Object is in trigger");
        // Here you add negative forces to object that is within the fan area
        // Other is the object, that should be pushed away
        /*Vector3 position = transform.position;
        Vector3 targetPosition = collision.transform.position;
        Vector3 direction = targetPosition - position;
        direction.Normalize();
        collision.transform.position += direction * moveSpeed * Time.deltaTime;*/

        collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveSpeed * Time.deltaTime);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Object left the trigger");
    }
}
