using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Red", menuName = "Inventory/Items/Red")]
public class Red : Inventar
{
    
    void Start()
    {
        itemTipe = ItemTipe.Red;
    }
}
