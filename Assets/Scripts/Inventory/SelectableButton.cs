using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class SelectableButton : MonoBehaviour
{
    public SelectableButtonsHandler selectableButtonsHandler;

    [SerializeField] protected Image image;
    [SerializeField] protected Button button;

    protected virtual void Start()
    {
        AddListeners();
    }

    protected virtual void AddListeners()
    {
        button.onClick.AddListener(TryToSelect);
    }

    public virtual void SetSelected()
    {
        image.color = Color.green;
    }

    public virtual void Unselect()
    {
        image.color = Color.white;
    }

    public virtual void TryToSelect()
    {
        selectableButtonsHandler.ChangeObjectType(this);
        Debug.Log("TryToSelect");
    }
}