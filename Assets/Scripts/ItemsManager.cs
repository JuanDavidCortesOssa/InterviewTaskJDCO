using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemsManager : Singleton<ItemsManager>
{
    [SerializeField] private List<ItemSO> itemsList;

    public Dictionary<int, ItemSO> itemsDictionary = new Dictionary<int, ItemSO>();

    private void Start()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        foreach (var itemSo in itemsList)
        {
            itemsDictionary.Add(itemSo.id, itemSo);
        }
    }

    public ItemSO GetItem(int id)
    {
        if (itemsDictionary.TryGetValue(id, out var item))
        {
            return item;
        }

        Debug.LogError($"Item with ID {id} not found!");
        return null;
    }
}