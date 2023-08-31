using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Manager<T> : MonoBehaviour where T : Component
{
    protected virtual void OnEnable()
    {
        ConfigureSubscriptions(true);
    }
    protected virtual void OnDisable()
    {
        ConfigureSubscriptions(false);
    }

    protected abstract void ConfigureSubscriptions(bool status);
}
