using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableInventory : MonoBehaviour
{
    public List<InventoryItemButton> inventoryItemButtons;

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
        ItemSelectionChannel.ItemInitialized += InitializeDefaultItems;
    }

    private void RemoveListeners()
    {
        ItemSelectionChannel.ItemInitialized -= InitializeDefaultItems;
    }

    private void InitializeDefaultItems(int objectId)
    {
        foreach (var inventoryItemButton in inventoryItemButtons)
        {
            if (inventoryItemButton.id == objectId)
            {
                inventoryItemButton.TryToSelect();
            }
        }
    }
}