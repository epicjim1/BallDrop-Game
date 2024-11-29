using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject normalObject;
    public GameObject cornerObject;
    public GameObject spinningObject;
    public GameObject bounceObject;
    public GameObject rampRObject;
    public GameObject rampLObject;

    [HideInInspector]
    public GameObject normalInstance;
    [HideInInspector]
    public GameObject cornerInstance;
    [HideInInspector]
    public GameObject spinningInstance;
    [HideInInspector]
    public GameObject bounceInstance;
    [HideInInspector]
    public GameObject rampRInstance;
    [HideInInspector]
    public GameObject rampLInstance;

    public void Normal()
    {
        normalInstance = Instantiate(normalObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)), normalObject.transform.rotation);
    }

    public void Corner()
    {
        cornerInstance = Instantiate(cornerObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)), normalObject.transform.rotation);
    }

    public void Spinning()
    {
        spinningInstance = Instantiate(spinningObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)), normalObject.transform.rotation);
    }

    public void Bounce()
    {
        spinningInstance = Instantiate(bounceObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)), normalObject.transform.rotation);
    }

    public void RampR()
    {
        rampRInstance = Instantiate(rampRObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)), rampRObject.transform.rotation);
    }

    public void RampL()
    {
        rampLInstance = Instantiate(rampLObject, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10)), rampLObject.transform.rotation);
    }
}
