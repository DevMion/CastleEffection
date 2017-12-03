﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Scene : MonoBehaviour
{
    public abstract void Init();
    public abstract void Release();
}