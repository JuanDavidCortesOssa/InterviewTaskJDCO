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
}