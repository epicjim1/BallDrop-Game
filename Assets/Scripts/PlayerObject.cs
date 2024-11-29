using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public bool isSelected;
    [HideInInspector]
    bool isPicked;
    //[HideInInspector]
    public bool isMovable = true;
    Circle circle;

    SpriteRenderer mySpriteComponent;
    Sprite normalSprite;
    public Sprite selectedSprite;
    public bool isRamp;
    Animator myAnim;
    [SerializeField]
    RuntimeAnimatorController normalAnim;
    public RuntimeAnimatorController selectedAnim;

    public bool usesBox;
    public bool usesPoly;

    private void Start()
    {
        //Circle circle = player.GetComponent<Circle>();
        mySpriteComponent = gameObject.GetComponent<SpriteRenderer>();
        normalSprite = mySpriteComponent.sprite;

        if (isRamp)
        {
            myAnim = GetComponent<Animator>();
            normalAnim = myAnim.runtimeAnimatorController;
        }
        circle = GameObject.FindGameObjectWithTag("Circle").GetComponent<Circle>();
    }

    void Update()
    {
        //if (isPicked == true && isMovable == true && Input.touchCount == 1)
        if (isPicked == true && isMovable == true)
            {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                transform.eulerAngles += new Vector3(0f, 0f, 15f);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                transform.eulerAngles += new Vector3(0f, 0f, -15f);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isPicked = false;
            }

            //mySpriteComponent.sprite = selectedSprite;
        }
        /*else
        {
            mySpriteComponent.sprite = normalSprite;
        }*/

        if (circle.objIsMovable == false)
        {
            isMovable = false;
            //Debug.Log("not moving");
        }
        else
        {
            //Debug.Log("moving");
            //StartCoroutine(reEnable());
        }
    }

    void OnMouseDown()
    {
        isPicked = true;
        /*if (ClickSelect() == this.gameObject)
        {
            Debug.Log("selected" + transform.name);
            isSelected = true;
        }
        else
        {
            isSelected = false;
        }*/
    }

    public IEnumerator reEnable()
    {
        if (usesBox)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if (usesPoly)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            yield return new WaitForSeconds(0.5f);
            GetComponent<PolygonCollider2D>().enabled = true;
        }
    }

    //This method returns the game object that was clicked using Raycast 2D
    GameObject ClickSelect()
    {
        //Converting $$anonymous$$ouse Pos to 2D (vector2) World Pos
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            //Debug.Log(hit.transform.name);
            return hit.transform.gameObject;
        }
        else return null;
    }

    public void Selected () 
    {
        mySpriteComponent.sprite = selectedSprite;
    }

    public void DeSelect()
    {
        mySpriteComponent.sprite = normalSprite;
    }

    public void SelectedRamp()
    {
        myAnim.runtimeAnimatorController = selectedAnim;
    }

    public void DeSelectRamp()
    {
        myAnim.runtimeAnimatorController = normalAnim;
    }
}
