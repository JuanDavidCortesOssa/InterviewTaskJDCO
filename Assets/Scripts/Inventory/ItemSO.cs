using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Scriptable Objects/ New Item")]
public class ItemSO : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public int cost;
    public ObjectType objectType;
}

public enum ObjectType
{
    Hood,
    Torso,
    Pelvis
}