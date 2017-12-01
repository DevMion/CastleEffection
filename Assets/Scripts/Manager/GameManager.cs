using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Quit()
    {
        // 데이터 세이브
        Debug.Log("Quit");
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        // 데이터 세이브
        Debug.Log("OnQuit");
    }
}