using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMoney : CollectableObject
{
    [SerializeField] private int moneyToGive;

    protected override void PickUp()
    {
        StoreManager.Instance.AddToPlayerBalance(moneyToGive);
    }
}