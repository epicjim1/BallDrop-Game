using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PanZoom : MonoBehaviour
{
    Vector3 touchStart;
    public float zoomOutMin = 8;
    public float zoomOutMax = 16;
    private bool multiTouch = false;
    public GameObject cmCam;

    public float minimoX, minimoY, maximoX, maximoY;


    public Transform player;
    public float speed = 5f;
    private bool touchStart2;
    private Vector2 pointA;
    private Vector2 pointB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            multiTouch = false;
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        /*if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }*/
        if (Input.touchCount == 2)
        {
            multiTouch = true;
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f);
        }
        /*else if (Input.GetMouseButton(0) && multiTouch == false)
        {
            Vector3 dir = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += dir;

            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += direction;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimoX, maximoX), Mathf.Clamp(transform.position.y, minimoY, maximoY), -10);
        }*/
        zoom(Input.GetAxis("Mouse ScrollWheel"));


        /*if (Input.GetMouseButtonDown(0))
        {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * -1;
            outerCircle.transform.position = pointA * -1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (Input.GetMouseButton(0))
        {
            touchStart2 = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart2 = false;
        }*/

    }

    /*private void FixedUpdate()
    {
        if (touchStart2)
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * -1);

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;
        }
        else
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }*/

    void zoom(float increment)
    {
        //Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
        cmCam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = Mathf.Clamp(cmCam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize - increment, zoomOutMin, zoomOutMax);
    }

    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);
    }
}
