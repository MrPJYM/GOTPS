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
    //private ItemSlot _selectedSlot; // ������ ������ ������ ����
    //private ItemData _tempData; // �ӽ� ������ ������ ����
    //bool IsDragging;
    ////public List<ItemSlot> itemSlots;
    //public ItemData moveItemData;
    //public Image moveImage;
    //Slot selectedSlot;
    //void Start()
    //{
    //    slots = System.Linq.Enumerable.ToList(GetComponentsInChildren<Slot>());
    //    for (int i = 0; i < slots.Count; i++)
    //    {
    //        slots[i].SetSlotID(i);
    //        //slots[i].OnBeginDragEvent += OnBeginDrag;
    //        //slots[i].OnDragEndEvent += OnDragEnd;
    //        //slots[i].OnDragEvent += OnDrag;
    //        slots[i].OnPointerDownEvent += OnPointerDown;
    //    }
    //    ItemSlot tmp= slots[0] as ItemSlot;
    //    tmp.AssignItem(LoadManager.instance.items["item_potion_hp_01"], 0);
    //}
    //public override void AssginSlot(int i,ItemData data)
    //{
    //    ItemSlot tmp = slots[i] as ItemSlot;
    //    tmp.AssignItem(data, 1);
    //}

    //public void OnPointerDown(PointerEventData _eventData)
    //{
    //    foreach (ItemSlot data in slots)
    //    {
    //        if (data.IsInRect(_eventData.position))
    //        {
    //            if (data.isAssigned)
    //            {
    //                moveImage.transform.position = _eventData.position;
    //                moveImage.gameObject.SetActive(true);
    //                moveItemData = data.itemdata;
    //                moveImage.sprite = data.itemdata.item_Sprite;
    //                selectedSlot = data;
    //            }
    //        }
    //    }
    //}
    //public override void OnDrag(PointerEventData _eventData)
    //{    
    //    moveImage.transform.position = _eventData.position;
    //    Debug.Log(_eventData);
    //}
    //public override void OnBeginDrag(PointerEventData eventData)
    //       => IsDragging = true;
    //public override void OnEndDrag(PointerEventData eventData)
    //{
    //    IsDragging = false;
    //    foreach (ItemSlot data in slots)
    //    {
    //        if (data.IsInRect(eventData.position))
    //        {
    //            data.SwapSlot(slots[slotID], true);
    //            break;
    //        }
    //    }
    //}
}
