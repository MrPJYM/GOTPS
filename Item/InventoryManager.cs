using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler, IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public static InventoryManager instance;
    public List<InventoryObj> currentinventories;
    public ItemInventoryObj playerinventory;
    public ItemData moveItemData;
    public Image moveImage;
    Slot selectedSlot;
    bool canDrag;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        playerinventory = currentinventories[0] as ItemInventoryObj;
    }
    public void OnPointerDown(PointerEventData _eventData)
    {
        selectedSlot = null;
        canDrag = false;
        foreach (var inventory in currentinventories)
        {
            if (inventory.gameObject.activeSelf)
            {
                selectedSlot=inventory.OnPointerDownE(_eventData);
            }
            if (selectedSlot != null)
            {
                canDrag = true;
                moveImage.gameObject.SetActive(true);
                moveImage.sprite = selectedSlot.itemData.item_Sprite;
                moveItemData = selectedSlot.itemData;
                moveImage.gameObject.transform.position = _eventData.position;
                break;
            }
        }
    }
    public void OnPointerUp(PointerEventData _eventData)
    {
        moveImage.sprite = null;
        moveItemData = null;
        moveImage.gameObject.SetActive(false);
    }
    public void OnBeginDrag(PointerEventData _eventData)
    {
        if (!canDrag)
            return;
    }
    public void OnDrag(PointerEventData _eventData)
    {
        if (!canDrag)
            return;
        moveImage.transform.position = _eventData.position;
    }
    public void OnEndDrag(PointerEventData _eventData)
    {
        if (!canDrag)
            return;
        foreach (var inventory in currentinventories)
        {
            if (inventory.gameObject.activeSelf)
            {
                foreach (var slot in inventory.slots)
                {
                    if (slot.IsInRect(_eventData.position))
                    {
                        inventory.EndDrag(selectedSlot,slot);
                        moveImage.sprite = null;
                        moveItemData = null;
                        moveImage.gameObject.SetActive(false);
                        return;
                    }
                }
            }
        }
        moveImage.sprite = null;
        moveItemData = null;
        moveImage.gameObject.SetActive(false);
    }
    void Update()
    {
        if (PlayerInput.instance.IsInvectory)
        {
            playerinventory.gameObject.transform.parent.gameObject.SetActive(!playerinventory.gameObject.transform.parent.gameObject.activeSelf);
            if (playerinventory.gameObject.transform.parent.gameObject.activeSelf)
                currentinventories.Add(playerinventory);
            else
                currentinventories.Remove(playerinventory);
        }
    }
}
