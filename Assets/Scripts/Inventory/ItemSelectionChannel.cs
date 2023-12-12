using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemSelectionChannel
{
    public static event Action<int> ItemSelected;

    public static void OnItemSelected(int obj)
    {
        ItemSelected?.Invoke(obj);
    }
    
    public static event Action<int> ItemInitialized;

    public static void OnItemInitialized(int obj)
    {
        ItemInitialized?.Invoke(obj);
    }
}