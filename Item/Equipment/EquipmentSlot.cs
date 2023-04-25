using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    public EquipmentType slotEquipmentType;
    public ItemData AssignedItem { get; private set; }
    public bool AssignEquipment(ItemData item)
    {
        if (!item.Type.Equals(slotEquipmentType))
            return false;

        this.Unassign(); // 슬롯 초기화
        base.Assign(item.item_Sprite); // 베이스 슬롯 할당(이미지 변경 등)
        AssignedItem = item; // 아이템 정보 할당
        return true;
    }
    public override void Unassign()
    {
        base.Unassign();
        AssignedItem = null;
    }
}
