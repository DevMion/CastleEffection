using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingScene : Scene
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
        Debug.Log("TrainingScene Init");
    }

    public override void Release()
    {
        Debug.Log("TrainingScene Release");
        SoundManager.instance.Stop();
    }
}