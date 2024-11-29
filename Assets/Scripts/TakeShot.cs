using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeShot : MonoBehaviour
{
    public int count = 0;

    /*private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }*/

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot("/Users/Abhishek L/Downloads/myGames2/Ball Puzzle/sc/ipad2/capture.png");
        }
    }
}
