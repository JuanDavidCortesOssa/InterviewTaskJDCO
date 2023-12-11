using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryItemButton : SelectableButton
{
    [SerializeField] private Image imageIcon;
    [SerializeField] private int _id;

    public void Setup(int id, Sprite sprite, SelectableButtonsHandler handler)
    {
        selectableButtonsHandler = handler;
        _id = id;
        imageIcon.sprite = sprite;
    }

    public override void SetSelected()
    {
        base.SetSelected();
        ItemSelectionChannel.OnItemSelected(_id);
    }
}