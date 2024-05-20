using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTipe {Red, Yellow, Blue, black }
public class Inventar : ScriptableObject
{
    public string _name;
    public int maxcount;
    public ItemTipe itemTipe;
    public GameObject _itemPrefab;
    public Sprite icon;
}
