using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    [SerializeField] private GameObject saleableItemPrefab;
    [SerializeField] private Transform inventoryContentTransform;
    public Dictionary<int, SaleableItem> inventory = new Dictionary<int, SaleableItem>();

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        InventoryCommunicationChannel.ItemSelected += LockObjectSelling;
        InventoryCommunicationChannel.ItemUnselected += UnlockObjectSelling;
    }

    public void AddToInventory(int id)
    {
        inventory.Add(id, SpawnObject(id));
    }

    public void RemoveFromInventory(int id)
    {
        if (!inventory.TryGetValue(id, out var saleableItem)) return;

        Destroy(saleableItem.gameObject);
        inventory.Remove(id);
    }

    private SaleableItem SpawnObject(int id)
    {
        var instance = Instantiate(saleableItemPrefab, inventoryContentTransform);
        if (instance == null) return null;
        var saleableItem = instance.GetComponent<SaleableItem>();
        if (saleableItem != null)
        {
            saleableItem.Setup(ItemsManager.Instance.GetItem(id));
        }

        return saleableItem;
    }

    private void LockObjectSelling(int id)
    {
        if (!inventory.TryGetValue(id, out var saleableItem)) return;
        saleableItem.LockForSelling();
    }

    private void UnlockObjectSelling(int id)
    {
        if (!inventory.TryGetValue(id, out var saleableItem)) return;
        saleableItem.UnlockForSelling();
    }
}