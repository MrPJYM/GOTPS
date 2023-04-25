using UnityEngine;
using UnityEngine.EventSystems;
public class WeaponSlot : Slot //EquipmentSlot
{
    public EquipmentType slotEquipmentType;
    public ItemData AssignedItem { get; private set; }
    public bool AssignWeapon(ItemData item)
    {
        if (!item.Category.Equals(slotCategory))
            return false;
        this.Unassign(); 
        itemData = item; // 아이템 정보 할당
        Debug.Log(item.item_Sprite);
        this.Assign(item.item_Sprite);
        return true;
    }
    public override void Unassign()
    {
        base.Unassign();
        AssignedItem = null;
    }
}