using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interacter : MonoBehaviour
{
    [HideInInspector]
    public bool Active;

    protected virtual void Start()
    {
        Active = false;
    }

    public abstract void Interact(GameObject player);
}