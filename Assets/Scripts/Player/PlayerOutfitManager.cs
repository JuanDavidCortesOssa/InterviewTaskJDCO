using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutfitManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hoodSpriteRenderer;
    [SerializeField] private SpriteRenderer torsoSpriteRenderer;
    [SerializeField] private SpriteRenderer pelvisSpriteRenderer;

    [SerializeField] private List<int> defaultPlayerSkins;

    private void Start()
    {
        AddListeners();
        InitializePlayerDefaultSkin();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        InventoryCommunicationChannel.ItemSelected += SetSelectedItem;
    }

    private void RemoveListeners()
    {
        InventoryCommunicationChannel.ItemSelected -= SetSelectedItem;
    }

    private void SetSelectedItem(int id)
    {
        var itemSo = ItemsManager.Instance.GetItem(id);

        switch (itemSo.objectType)
        {
            case ObjectType.Hood:
                hoodSpriteRenderer.sprite = itemSo.sprite;
                break;
            case ObjectType.Torso:
                torsoSpriteRenderer.sprite = itemSo.sprite;
                break;
            case ObjectType.Pelvis:
                pelvisSpriteRenderer.sprite = itemSo.sprite;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void InitializePlayerDefaultSkin()
    {
        foreach (var skinId in defaultPlayerSkins)
        {
            InventoryCommunicationChannel.OnItemInitialized(skinId);
        }
    }
}