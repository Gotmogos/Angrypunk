using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Yellow", menuName = "Inventory/Items/Yellow")]
public class Yellow : Inventar
{
    [SerializeField]private int _countAmmo;
    void Start()
    {
        itemTipe = ItemTipe.Yellow;
    }
}
