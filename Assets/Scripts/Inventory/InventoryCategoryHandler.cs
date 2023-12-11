using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCategoryHandler : MonoBehaviour
{
    private CategoryButton _currentSelectedButton;

    public void ChangeObjectType(CategoryButton categoryButton)
    {
        if (categoryButton == _currentSelectedButton) return;

        if (_currentSelectedButton != null)
        {
            _currentSelectedButton.Unselect();
        }

        categoryButton.SetSelected();
        _currentSelectedButton = categoryButton;
    }
}