using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private Button inventoryButton;

    [SerializeField] private GameObject store;

    [SerializeField] private GameObject dialogPanel;

    private void Start()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        inventoryButton.onClick.AddListener(ToggleInventory);
    }

    #region Invnetory

    public void ToggleInventory()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
    }

    public void ActivateInventoryButton()
    {
        inventoryButton.gameObject.SetActive(true);
    }

    public void DeactivateInventoryButton()
    {
        inventoryButton.gameObject.SetActive(false);
    }

    #endregion

    #region DialogPanel

    public void ToggleDialogPanel()
    {
        dialogPanel.SetActive(!dialogPanel.activeSelf);
    }

    public void OpenDialogPanel()
    {
        dialogPanel.SetActive(true);
    }

    public void CloseDialogPanel()
    {
        dialogPanel.SetActive(false);
    }

    #endregion


    public void OpenStore()
    {
        store.SetActive(store);
    }
}