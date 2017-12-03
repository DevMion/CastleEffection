using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : Scene
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Init()
    {
        Debug.Log("LoadingScene Init");
    }

    public override void Release()
    {
        Debug.Log("LoadingScene Release");
        SoundManager.instance.Stop();
    }
}