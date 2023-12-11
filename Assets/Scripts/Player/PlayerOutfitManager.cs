using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutfitManager : MonoBehaviour
{
    [SerializeField] private SpriteRenderer hoodSpriteRenderer;
    [SerializeField] private SpriteRenderer torsoSpriteRenderer;
    [SerializeField] private SpriteRenderer pelvisSpriteRenderer;

    private void Start()
    {
        AddListeners();
    }

    private void OnDisable()
    {
        RemoveListeners();
    }

    private void AddListeners()
    {
        ItemSelectionChannel.ItemSelected += SetSelectedItem;
    }

    private void RemoveListeners()
    {
        ItemSelectionChannel.ItemSelected -= SetSelectedItem;
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
}