using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour//, IPointerDownHandler//, IPointerUpHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int slotId;
    internal void SetSlotID(int i) { slotId = i; }
    public ItemData itemData;
    public Category slotCategory;
    public Image icon;
    public RectTransform slot_rec;
    public bool isAssigned { get; private set; }
    [SerializeField]
    internal bool canDrag;
    //x,y
    protected float xMin;
    public float XMIN
    {
        get
        {
            xMin = transform.position.x - slot_rec.rect.width * 0.5f;
            return xMin;
        }
    }
    protected float xMax;
    public float XMAX
    {
        get
        {
            xMax = transform.position.x + slot_rec.rect.width * 0.5f;
            return xMax;
        }
    }
    protected float yMin;
    public float YMIN
    {
        get
        {
            yMin = transform.position.y - slot_rec.rect.height * 0.5f;
            return yMin;
        }
    }
    protected float yMax;
    public float YMAX
    {
        get
        {
            yMax = transform.position.y + slot_rec.rect.height * 0.5f;
            return yMax;
        }
    }
    private void Awake()
    {
        slot_rec = GetComponent<RectTransform>();
    }
    public virtual void Assign(Sprite sprite)
    {
        icon.sprite = sprite;
        icon.gameObject.SetActive(true);
        isAssigned = true;
        canDrag = true;
    }
    public virtual void Unassign()
    {
        isAssigned = false;
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        canDrag = false;
    }
    public bool IsInRect(Vector2 pos)
    {
        if (pos.x >= XMIN && pos.x <= XMAX && pos.y >= YMIN && pos.y <= YMAX)
        {
            return true;
        }
        return false;
    }
    public virtual void SwapSlot(Slot target)
    {
        
    }
    public enum 가나다
    {
        널,
        날,
        눌
    }
    //public UnityAction<int> OnAssignEvent;
    //public UnityAction<int, int> OnSwapEvent;
    ////public UnityAction<PointerEventData> OnBeginDragEvent;
    ////public UnityAction<int, PointerEventData> OnDragEndEvent;
    //public UnityAction<int> OnRightClickEvent;
    //public UnityAction<int> OnLeftClickEvent;
    //public UnityAction<PointerEventData> OnPointerDownEvent;
    ////public UnityAction<PointerEventData> OnDragEvent;
}