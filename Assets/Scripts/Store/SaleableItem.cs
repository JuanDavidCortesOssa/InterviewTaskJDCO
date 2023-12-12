using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaleableItem : StoreItem
{
    protected override void Start()
    {
        AddListeners();
    }

    protected override void SetSelected()
    {
        backgroundImage.color = Color.green;
        StoreManager.Instance.AddToSalesCart(this);
    }

    protected override void Unselect()
    {
        backgroundImage.color = Color.gray;
        StoreManager.Instance.RemoveFromSalesCart(this);
    }

    public override void SetAsSold()
    {
        PlayerInventory.Instance.RemoveFromInventory(id);
    }

    public override void AddToStock()
    {
        //Add to stock
    }
}