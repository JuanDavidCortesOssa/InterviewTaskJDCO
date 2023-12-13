using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour, IInteractable
{
    public virtual void Interact()
    {
        PickUp();
        gameObject.SetActive(false);
    }

    protected abstract void PickUp();
}