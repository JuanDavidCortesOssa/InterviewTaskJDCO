using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableInventory : MonoBehaviour
{
    public List<InventoryItemButton> inventoryItemButtons;

    private Dictionary<int, InventoryItemButton> inventoryItemButtonsDictionary =
        new Dictionary<int, InventoryItemButton>();

    private void Start()
    {
        InitializeDictionary();
    }

    private void OnEnable()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        InventoryCommunicationChannel.ItemInitialized += InitializeDefaultItems;
        InventoryCommunicationChannel.ItemPurchased += UnlockItemOnInventory;
        InventoryCommunicationChannel.ItemSold += LockItemOnInventory;
    }

    private void RemoveListeners()
    {
        InventoryCommunicationChannel.ItemInitialized -= InitializeDefaultItems;
        InventoryCommunicationChannel.ItemPurchased -= UnlockItemOnInventory;
        InventoryCommunicationChannel.ItemSold -= LockItemOnInventory;
    }

    private void InitializeDefaultItems(int objectId)
    {
        foreach (var inventoryItemButton in inventoryItemButtons)
        {
            if (inventoryItemButton.id == objectId)
            {
                inventoryItemButton.TryToSelect();
            }
            else
            {
                if (inventoryItemButton.isSelected == false)
                {
                    inventoryItemButton.Lock();
                }
            }
        }
    }

    private void InitializeDictionary()
    {
        foreach (var itemButton in inventoryItemButtons)
        {
            inventoryItemButtonsDictionary.Add(itemButton.id, itemButton);
        }
    }

    private void UnlockItemOnInventory(int id)
    {
        if (!inventoryItemButtonsDictionary.TryGetValue(id, out var obj)) return;
        obj.Unlock();
    }

    private void LockItemOnInventory(int id)
    {
        if (!inventoryItemButtonsDictionary.TryGetValue(id, out var obj)) return;
        obj.Lock();
    }
}