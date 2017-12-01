using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFPS : MonoBehaviour
{
    private float deltaTime = 0.0f;
    private GUIStyle guiStyle = null;
    private Rect printArea;

	// Use this for initialization
	void Start ()
    {
        guiStyle = new GUIStyle();
        guiStyle.alignment = TextAnchor.UpperLeft;
        guiStyle.fontSize = Screen.height / 25;
        guiStyle.normal.textColor = Color.green;//new Color(0.0f, 0.0f, 0.5f, 1.0f);
        printArea = new Rect(0, 0, Screen.width, Screen.height / 25);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        deltaTime = Time.unscaledDeltaTime;
    }

    private void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        float fps = Time.timeScale / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0} fps)", msec, fps);
        if(fps < 10)
        {
            guiStyle.normal.textColor = Color.red;
        }
        else if(fps < 30)
        {
            guiStyle.normal.textColor = Color.yellow;
        }
        else
        {
            guiStyle.normal.textColor = Color.green;
        }
        GUI.Label(printArea, text, guiStyle);
    }
}
