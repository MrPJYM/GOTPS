using UnityEngine.EventSystems;

public class EquipmentSlot : Slot
{
    public EquipmentType slotEquipmentType;
    public ItemData AssignedItem { get; private set; }
    public bool AssignEquipment(ItemData item)
    {
        if (!item.Type.Equals(slotEquipmentType))
            return false;

        this.Unassign(); // ���� �ʱ�ȭ
        base.Assign(item.item_Sprite); // ���̽� ���� �Ҵ�(�̹��� ���� ��)
        AssignedItem = item; // ������ ���� �Ҵ�
        return true;
    }
    public override void Unassign()
    {
        base.Unassign();
        AssignedItem = null;
    }
}
