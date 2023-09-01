using UnityEngine;

public abstract class Actor<T> : MonoBehaviour where T : Manager<T>
{
    [SerializeField] protected T Manager;

    protected virtual void OnEnable()
    {
        ConfigureSubscriptions(true);
    }
    protected virtual void OnDisable()
    {
        ConfigureSubscriptions(false);
    }

    protected virtual void ConfigureSubscriptions(bool status) { }
}
