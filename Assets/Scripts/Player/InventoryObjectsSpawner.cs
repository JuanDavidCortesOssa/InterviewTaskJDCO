using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject inventoryItemButtonPrefab;
    [SerializeField] private SelectableButtonsHandler selectableButtonsHandler;
    [SerializeField] private Transform parentTransform;
    [SerializeField] private List<ItemSO> itemsToSpawn;

    [ContextMenu("Spawn Item Buttons")]
    public void InstantiateInventoryObjects()
    {
        var itemsDictionary = ItemsManager.Instance.itemsDictionary;
        foreach (var itemSo in itemsToSpawn)
        {
            InstantiateInventoryItemButton(itemSo.id, itemSo.sprite);
        }
    }

    public void InstantiateInventoryItemButton(int id, Sprite sprite)
    {
#if UNITY_EDITOR
        GameObject instance = PrefabUtility.InstantiatePrefab(inventoryItemButtonPrefab, parentTransform) as GameObject;

        if (instance == null) return;

        InventoryItemButton inventoryItemButton = instance.GetComponent<InventoryItemButton>();

        if (inventoryItemButton != null)
        {
            inventoryItemButton.Setup(id, sprite, selectableButtonsHandler);
        }
        else
        {
            Debug.LogError("The instantiated object doesn't have the InventoryItemButton component.");
        }

#endif
    }
}