using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    public int id;
    public int price;
    [SerializeField] protected Image iconImage;
    [SerializeField] protected Image backgroundImage;
    [SerializeField] protected Button button;

    private bool isSelected = false;

    protected virtual void Start()
    {
        Setup(ItemsManager.Instance.GetItem(id));
        AddListeners();
    }

    protected void AddListeners()
    {
        button.onClick.AddListener(ToggleSelection);
    }

    public void Setup(ItemSO itemSo)
    {
        id = itemSo.id;
        price = itemSo.cost;
        iconImage.sprite = itemSo.sprite;
    }

    public void Setup(int newId, int newPrice, Sprite sprite)
    {
        id = newId;
        price = newPrice;
        iconImage.sprite = sprite;
    }

    protected virtual void SetSelected()
    {
        backgroundImage.color = Color.green;
        StoreManager.Instance.AddToShopCart(this);
    }

    protected virtual void Unselect()
    {
        backgroundImage.color = Color.white;
        StoreManager.Instance.RemoveFromShopCart(this);
    }

    public virtual void SetAsSold()
    {
        backgroundImage.color = Color.black;
        button.enabled = false;
    }

    public virtual void AddToStock()
    {
        backgroundImage.color = Color.white;
        button.enabled = true;
        isSelected = false;
    }

    private void ToggleSelection()
    {
        if (isSelected)
        {
            Unselect();
        }
        else
        {
            SetSelected();
        }

        isSelected = !isSelected;
    }
}