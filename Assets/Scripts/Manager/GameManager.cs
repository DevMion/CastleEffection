using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        Debug.Log("Awake Game");
        if (!instance)
        {
            Debug.Log("Dont Destroy");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != instance)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }

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

    // 강제 종료시 호출됨
    // Application.Quit()시에도 호출되는지 테스트 필요
    private void OnApplicationQuit()
    {
        // 데이터 세이브
        Debug.Log("OnQuit");
    }
}