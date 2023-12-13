using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesMan : MonoBehaviour
{
    public Action<Dialogue> InitDialogue;
    [SerializeField] private Dialogue helloDialogue;
    [SerializeField] private Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.OpenDialogPanel();
            UIManager.Instance.DeactivateInventoryButton();
            InitDialogue.Invoke(helloDialogue);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.CloseDialogPanel();
            UIManager.Instance.ActivateInventoryButton();
        }
    }
}