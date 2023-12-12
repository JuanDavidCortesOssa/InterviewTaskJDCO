using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreManager : Singleton<StoreManager>
{
    public int playerBalance;
    [SerializeField] private int totalPrice = 0;
    [SerializeField] private int temporalBalance = 0;

    [SerializeField] private StoreUI storeUI;

    private List<StoreItem> shopCartItems = new List<StoreItem>();
    private Dictionary<int, StoreItem> soldItems = new Dictionary<int, StoreItem>();

    private List<SaleableItem> salesCartItems = new List<SaleableItem>();

    public void AddToShopCart(StoreItem storeItem)
    {
        shopCartItems.Add(storeItem);
        AddToPurchase(storeItem.price);
        storeUI.SetPurchaseText(temporalBalance, totalPrice);
    }

    public void RemoveFromShopCart(StoreItem storeItem)
    {
        shopCartItems.Remove(storeItem);
        RemoveFromPurchase(storeItem.price);
        storeUI.SetPurchaseText(temporalBalance, totalPrice);
    }

    public void AddToSalesCart(SaleableItem saleableItem)
    {
        salesCartItems.Add(saleableItem);
        RemoveFromPurchase(saleableItem.price);
        storeUI.SetPurchaseText(temporalBalance, totalPrice);
    }

    public void RemoveFromSalesCart(SaleableItem saleableItem)
    {
        salesCartItems.Remove(saleableItem);
        AddToPurchase(saleableItem.price);
        storeUI.SetPurchaseText(temporalBalance, totalPrice);
    }

    private void AddToPurchase(int productPrice)
    {
        totalPrice += productPrice;
        temporalBalance -= productPrice;
    }

    private void RemoveFromPurchase(int productPrice)
    {
        totalPrice -= productPrice;
        temporalBalance += productPrice;
    }

    private void SetFinalBalance()
    {
        playerBalance = temporalBalance;
        totalPrice = 0;
        storeUI.SetPurchaseText(temporalBalance, totalPrice);
    }

    public void BuyItems()
    {
        SetFinalBalance();

        for (var i = shopCartItems.Count - 1; i >= 0; i--)
        {
            var storeItem = shopCartItems[i];
            storeItem.SetAsSold();
            PlayerInventory.Instance.AddToInventory(storeItem.id);
            soldItems.Add(storeItem.id, storeItem);
            shopCartItems.RemoveAt(i);
            InventoryCommunicationChannel.OnItemPurchased(storeItem.id);
        }
    }

    public void SellItems()
    {
        SetFinalBalance();

        for (var i = salesCartItems.Count - 1; i >= 0; i--)
        {
            var saleableObject = salesCartItems[i];
            saleableObject.SetAsSold();
            ReturnItemToStore(saleableObject.id);
            salesCartItems.RemoveAt(i);
            InventoryCommunicationChannel.OnItemPurchased(saleableObject.id);
        }
    }

    private void ReturnItemToStore(int id)
    {
        soldItems.TryGetValue(id, out var soldItem);
        if (soldItem != null) soldItem.AddToStock();
        soldItems.Remove(id);
    }
}