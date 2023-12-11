using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class SelectableButton : MonoBehaviour
{
    public SelectableButtonsHandler selectableButtonsHandler;

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
        _button.onClick.AddListener(TryToSelect);
    }

    public virtual void SetSelected()
    {
        _image.color = Color.green;
    }

    public virtual void Unselect()
    {
        _image.color = Color.white;
    }

    protected virtual void TryToSelect()
    {
        selectableButtonsHandler.ChangeObjectType(this);
    }
}