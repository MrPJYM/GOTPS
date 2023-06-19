using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot firstSlot;
    WeaponHolderSlot secondSlot;
    WeaponHolderSlot thirdSlot;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isFirstSlot)
            {
                firstSlot = weaponSlot;
            }
            else if (weaponSlot.isSecondSlot)
            {
                secondSlot = weaponSlot;
            }
            else if (weaponSlot.isThirdlot)
            {
                thirdSlot= weaponSlot;
            }
        }

    }

    public void LoadWeaponOnSlot(ItemData weaponItem,byte isslot)
    {
        switch(isslot)
        {
            case 1:
                firstSlot.LoadWeaponModel(weaponItem);
                break;
            case 2:
                secondSlot.LoadWeaponModel(weaponItem);
                break;
            case 3:
                thirdSlot.LoadWeaponModel(weaponItem);
                break;
            default:
                break;
        }

    }
}
