using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
public class InventoryObj : MonoBehaviour//, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public List<Slot> slots;
    //public UnityAction<PointerEventData> OnPointerDown;

    public virtual Slot OnPointerDownE(PointerEventData _eventData)
    {
        foreach(var slot in slots)
        {
            if(slot.IsInRect(_eventData.position))
            {
                //OnPointerDown?.Invoke(_eventData);
                return slot;
            }
        }
        return null;
    }
    public virtual void EndDrag(Slot select,Slot target)
    {

    }
    //public virtual void AssginSlot(int i, ItemData data)
    //{

    //}
    //public virtual void OnPointerUp(PointerEventData _eventData)
    //{
    //}
    //public virtual void OnBeginDrag(PointerEventData _eventData)
    //{
    //}
    //public virtual void OnDrag(PointerEventData _eventData)
    //{
    //}
    //public virtual void OnEndDrag(PointerEventData _eventData)
    //{
    //}
}
