using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;
public class InventoryObj : MonoBehaviour
{
    public List<Slot> slots;
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
}
