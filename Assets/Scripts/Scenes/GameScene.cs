using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : Scene
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
        Debug.Log("GameScene Init");
    }

    public override void Release()
    {
        Debug.Log("GameScene Release");
        SoundManager.instance.Stop();
    }
}