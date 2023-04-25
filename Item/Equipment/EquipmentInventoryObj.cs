using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventoryObj : InventoryObj
{
    public CharacterControl control;
    public void AssginSlot(int i, ItemData data)
    {
        EquipmentSlot tmp = slots[i] as EquipmentSlot;
        tmp.AssignEquipment(data);
    }
    private void start()
    {
    }
    public override void EndDrag(Slot select, Slot target)
    {
        base.EndDrag(select, target);
        EquipmentSlot tmp = target as EquipmentSlot;
        if (select.itemData.Category!=Category.EQUIP || select.itemData.Type == EquipmentType.WEAPON)
            return;

        if (tmp.isAssigned)
        {
            return;
        }
        else
        {
            tmp.AssignEquipment(select.itemData);
            select.Unassign();
        }
    }
}
