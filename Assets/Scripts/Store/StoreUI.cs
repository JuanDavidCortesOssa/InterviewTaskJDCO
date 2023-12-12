using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balanceText;
    [SerializeField] private TextMeshProUGUI totalText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;

    private StoreManager _storeManager;

    private void Start()
    {
        InitializeVariables();
        AddListeners();
    }

    private void InitializeVariables()
    {
        _storeManager = StoreManager.Instance;
        SetPurchaseText(_storeManager.playerBalance, 0);
    }

    private void AddListeners()
    {
        buyButton.onClick.AddListener(_storeManager.BuyItems);
        sellButton.onClick.AddListener(_storeManager.SellItems);
    }

    public void SetPurchaseText(int playerBalance, int total)
    {
        balanceText.text = "$ " + playerBalance;
        totalText.text = "$ " + total;

        if (playerBalance >= 0)
        {
            if (!buyButton.enabled)
                ActivatePurchase();
        }
        else
        {
            if (buyButton.enabled)
                DeactivatePurchase();
        }
    }

    private void DeactivatePurchase()
    {
        balanceText.color = Color.red;
        buyButton.image.color = Color.gray;
        buyButton.enabled = false;
    }

    private void ActivatePurchase()
    {
        balanceText.color = Color.black;
        buyButton.image.color = Color.green;
        buyButton.enabled = true;
    }
}