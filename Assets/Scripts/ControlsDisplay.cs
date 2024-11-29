using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsDisplay : MonoBehaviour
{
    public GameObject ui;
    private bool controlOff = false;

    // Start is called before the first frame update
    void Start()
    {
        if (ui != null)
        {
            Circle.controlIsOff = false;
        }
        else
        {
            Circle.controlIsOff = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.activeInHierarchy == false && controlOff == false)
        {
            Circle.controlIsOff = true;
            controlOff = true;
        }
    }
}
