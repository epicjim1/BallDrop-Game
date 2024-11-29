using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OptionsMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ResetProgress()
    {
        Debug.Log("Progress deleted");
        PlayerPrefs.DeleteAll();
    }
}
