using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CategoryButton : SelectableButton
{
    [SerializeField] private GameObject itemsPanel;

    public override void SetSelected()
    {
        base.SetSelected();
        itemsPanel.SetActive(true);
    }

    public override void Unselect()
    {
        base.Unselect();
        itemsPanel.SetActive(false);
    }
}