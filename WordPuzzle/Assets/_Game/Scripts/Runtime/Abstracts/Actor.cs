using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Actor<T> : MonoBehaviour where T : Manager<T>
{
    public T Manager { get; set; }
}
