using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
public class WeaponInventoryObj : InventoryObj
{
    public CharacterControl control;
    public WeaponManager weaponManager { get; private set; }
    public void AssginSlot(int i, ItemData data)
    {
        WeaponSlot tmp = slots[i] as WeaponSlot;
        tmp.AssignWeapon(data);
    }
    private void start()
    {
        weaponManager = control.WM;
        foreach(WeaponSlot slot in slots)
        {
            weaponManager.weaponChangeF += slot.ChangeWeapon;
        }
    }
    public override void EndDrag(Slot select, Slot target)
    {
        base.EndDrag(select, target);
        WeaponSlot tmp = target as WeaponSlot;
        if (select.itemData.Type != EquipmentType.WEAPON)
            return;

        if (tmp.isAssigned)
        {
            return;
        }
        else
        {
            tmp.AssignWeapon(select.itemData);
            select.Unassign();
        }
    }
}
