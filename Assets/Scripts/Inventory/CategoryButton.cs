using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CategoryButton : MonoBehaviour
{
    [SerializeField] private InventoryCategoryHandler inventoryCategoryHandler;
    [SerializeField] private GameObject itemsPanel;
    private Image _image;
    private Button _button;

    private void Start()
    {
        InitializeVariables();
        AddListeners();
    }

    private void InitializeVariables()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
    }

    private void AddListeners()
    {
        _button.onClick.AddListener(TryChangeCategory);
    }

    public void SetSelected()
    {
        itemsPanel.SetActive(true);
        _image.color = Color.green;
    }

    public void Unselect()
    {
        itemsPanel.SetActive(false);
        _image.color = Color.white;
    }

    private void TryChangeCategory()
    {
        inventoryCategoryHandler.ChangeObjectType(this);
    }
}