using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItemButton : SelectableButton
{
    [SerializeField] private Image imageIcon;
    public int id;
    public bool isSelected = false;

    public void Setup(int newId, Sprite sprite, SelectableButtonsHandler handler)
    {
        selectableButtonsHandler = handler;
        id = newId;
        imageIcon.sprite = sprite;
    }

    public override void SetSelected()
    {
        base.SetSelected();
        ItemSelectionChannel.OnItemSelected(id);
        isSelected = true;
    }

    public override void Unselect()
    {
        base.Unselect();
        isSelected = false;
    }
}