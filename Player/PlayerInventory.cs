using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    WeaponSlotManager weaponSlotManager;
    public ItemData firstWeapon;
    public ItemData secondWeapon;
    public ItemData thirdWeapon;

    private void Awake()
    {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    private void Start()
    {
        weaponSlotManager.LoadWeaponOnSlot(firstWeapon, 1);
        weaponSlotManager.LoadWeaponOnSlot(secondWeapon, 2);
        weaponSlotManager.LoadWeaponOnSlot(thirdWeapon, 3);
    }
}
