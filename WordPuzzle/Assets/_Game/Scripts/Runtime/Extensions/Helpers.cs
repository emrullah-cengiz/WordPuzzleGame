using System;
using UnityEngine.Events;

public static class Helpers
{
    public static void Subscribe(this UnityEvent signal, UnityAction subscriber, bool status)
    {
        if (status)
            signal.AddListener(subscriber);
        else
            signal.RemoveListener(subscriber);
    }
}
