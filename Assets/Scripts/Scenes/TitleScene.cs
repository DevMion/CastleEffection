using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : Scene
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override void Init()
    {
        Debug.Log("TitleScene Init");
    }

    public override void Release()
    {
        Debug.Log("TitleScene Release");
        SoundManager.instance.Stop();
    }
}