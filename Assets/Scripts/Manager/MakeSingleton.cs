using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSingleton : MonoBehaviour
{
    static private MakeSingleton instance = null;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else// if(this != instance)
        {
            Destroy(gameObject);
        }
    }
}
