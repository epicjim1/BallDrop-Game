using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public LayerMask IgnoreMe;

    public Circle myCircle;
    public bool isMovable = true;

    GameObject currentSelect;
    GameObject nextSelect;
    GameObject prevSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        /*if (ClickSelect().CompareTag("Object"))
        {
            Debug.Log("selected" + transform.name);
            selected = ClickSelect();
        }*/
        ClickSelect();
        Debug.Log("mouseDown");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickSelect();
        }

        if (myCircle.objIsMovable == false)
        {
            isMovable = false;
        }
    }

    //This method returns the game object that was clicked using Raycast 2D
    void ClickSelect()
    {
        //Debug.Log("func called");
        //Converting $$anonymous$$ouse Pos to 2D (vector2) World Pos
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 100f, ~IgnoreMe);

        if (hit)
        {
            Debug.Log(hit.transform.name);
            //return hit.transform.gameObject;
            if (hit.transform.gameObject.tag == "Object" || hit.transform.gameObject.name == "bounceObj(Clone)" || hit.transform.gameObject.tag == "Ramp")
            {
                nextSelect = hit.transform.gameObject;

                if (currentSelect == null)
                {
                    currentSelect = nextSelect;
                }

                if (nextSelect != currentSelect)
                {
                    prevSelect = currentSelect;
                    currentSelect = nextSelect;
                    if (prevSelect.tag == "Ramp")
                    {
                        prevSelect.GetComponent<PlayerObject>().DeSelectRamp();
                    }
                    else
                    {
                        prevSelect.GetComponent<PlayerObject>().DeSelect();
                    }
                }


                if (currentSelect.tag == "Ramp")
                {
                    currentSelect.GetComponent<PlayerObject>().SelectedRamp();
                }
                else
                {
                    currentSelect.GetComponent<PlayerObject>().Selected();
                }
            }
            else
            {
                nextSelect = null;
            }
        }
        //else return null;
    }

    public void turnLeft ()
    {
        if (currentSelect != null && isMovable)
        {
            currentSelect.transform.eulerAngles += new Vector3(0f, 0f, 15f);
        }
    }

    public void turnRight ()
    {
        if (currentSelect != null && isMovable)
        {
            currentSelect.transform.eulerAngles += new Vector3(0f, 0f, -15f);
        }
    }
}
