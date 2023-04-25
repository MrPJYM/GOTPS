using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemSlot : Slot
{
    public int item_Amount { get; private set; }
    public TMP_Text text;
    void Awake()
    {
        slot_rec = GetComponent<RectTransform>();
        item_Amount = 0;
        text.text = item_Amount.ToString();
        text.color = Color.black;
    }
    public bool AssignItem(ItemData item, int amount)
    {
        this.Unassign();
        item_Amount = amount;// 슬롯 초기화
        itemData = item; // 아이템 정보 할당
        this.Assign(item.item_Sprite);
        return true;
    }
    public override void Unassign()
    {
        base.Unassign();
        itemData = null;
        item_Amount = 0;
    }

    //ItemInventoryObj itemInventoryObj;
    //public int item_Amount { get; private set; }
    //public TMP_Text text;
    //// Start is called before the first frame update
    //void Awake()
    //{
    //    itemInventoryObj = GetComponentInParent<ItemInventoryObj>();
    //    slot = GetComponent<RectTransform>();
    //    xMin = transform.position.x - slot.rect.width * 0.5f;
    //    xMax = transform.position.x + slot.rect.width * 0.5f;
    //    yMin = transform.position.y - slot.rect.height * 0.5f;
    //    yMax = transform.position.y + slot.rect.height * 0.5f;
    //    item_Amount = 0;

    //    text.text = item_Amount.ToString();
    //    text.color = Color.black;
    //}
    //public bool AssignItem(ItemData item, int amount)
    //{
    //    this.Unassign();
    //    item_Amount = amount;// 슬롯 초기화
    //    itemdata = item; // 아이템 정보 할당
    //    this.Assign(item.item_Sprite);
    //    return true;
    //}
    //public override void Unassign()
    //{
    //    base.Unassign();
    //    itemdata = null;
    //    item_Amount = 0;
    //    slotId = -1;
    //}

    //public override void increaseNum(int num)
    //{
    //    item_Amount += num;
    //    text.text = item_Amount.ToString();
    //}
    //// Update is called once per frame
    //public override void OnLeftClick()
    //{
    //    if (isAssigned)
    //        OnLeftClickEvent?.Invoke(slotId);
    //}

    //public override void OnRightClick()
    //{
    //    if (isAssigned)
    //        OnRightClickEvent?.Invoke(slotId);
    //}

    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    base.OnPointerDown(eventData);
    //}

    //public override void OnPointerUp(PointerEventData eventData)
    //{
    //    base.OnPointerUp(eventData);
    //}

    //public override void OnBeginDrag(PointerEventData eventData)
    //{
    //    IsOnLeftClick = false;
    //    IsOnRightClick = false;
    //    if (!isAssigned || !canDrag) return;
    //}
    //public override void OnDrag(PointerEventData eventData)
    //{
    //    if (!isAssigned) return;
    //}
    //public override void OnEndDrag(PointerEventData eventData)
    //{
    //    base.OnEndDrag(eventData);
    //}
    //public override void SwapSlot(Slot target, bool fixData)
    //{
    //    if (!target.canDrag || target == this)
    //        return;
    //    ItemSlot source = target as ItemSlot;
    //    if (!target.isAssigned)
    //    {
    //        source.AssignItem(itemdata, item_Amount);
    //        this.Unassign();
    //    }
    //    else
    //    {
    //        if (this.itemdata.Id.Equals(source.itemdata.Id) && this.itemdata.Category != Category.EQUIP)
    //        {
    //            this.increaseNum(this.item_Amount);
    //            this.Unassign();
    //            return;
    //        }
    //    }
    //    if (fixData) OnSwapEvent?.Invoke(this.slotId, source.slotId);
    //}
}
