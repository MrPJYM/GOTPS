using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemInventoryObj : InventoryObj
{
    void Start()
    {
        slots = System.Linq.Enumerable.ToList(GetComponentsInChildren<Slot>());
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].SetSlotID(i);
        }
        ItemSlot tmp = slots[0] as ItemSlot;
        tmp.AssignItem(LoadManager.instance.items["item_potion_hp_01"], 0);
    }
    public override void EndDrag(Slot select, Slot target)
    {
        base.EndDrag(select,target);
        ItemSlot tmp = target as ItemSlot;
        if (target.isAssigned) {

        }
        else
        {
            tmp.AssignItem(select.itemData, 1);
            select.Unassign();
        }
    }
}
