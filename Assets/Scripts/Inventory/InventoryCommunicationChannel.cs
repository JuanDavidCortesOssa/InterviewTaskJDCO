using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryCommunicationChannel
{
    public static event Action<int> ItemSelected;

    public static void OnItemSelected(int obj)
    {
        ItemSelected?.Invoke(obj);
    }

    public static event Action<int> ItemUnselected;

    public static void OnItemUnselected(int obj)
    {
        ItemUnselected?.Invoke(obj);
    }

    public static event Action<int> ItemInitialized;

    public static void OnItemInitialized(int obj)
    {
        ItemInitialized?.Invoke(obj);
    }

    public static event Action<int> ItemPurchased;

    public static void OnItemPurchased(int obj)
    {
        ItemPurchased?.Invoke(obj);
    }

    public static event Action<int> ItemSold;

    public static void OnItemSold(int obj)
    {
        ItemSold?.Invoke(obj);
    }
}