using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableButtonsHandler : MonoBehaviour
{
    [SerializeField] private SelectableButton _currentSelectedButton;

    public void ChangeObjectType(SelectableButton selectableButton)
    {
        if (selectableButton == _currentSelectedButton) return;

        if (_currentSelectedButton != null)
        {
            _currentSelectedButton.Unselect();
        }

        selectableButton.SetSelected();
        _currentSelectedButton = selectableButton;
    }
}