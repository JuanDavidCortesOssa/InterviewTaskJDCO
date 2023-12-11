using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private List<ItemSO> itemsList;

    private Dictionary<int, ItemSO> _itemsDictionary = new Dictionary<int, ItemSO>();

    private void Start()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        foreach (var itemSo in itemsList)
        {
            _itemsDictionary.Add(itemSo.id, itemSo);
        }
    }
}