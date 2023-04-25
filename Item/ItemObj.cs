using UnityEngine;

public class ItemObj : MonoBehaviour
{
    public ItemData data { get; protected set; }
    public ItemObj(ItemData setdata)
    {
        data = setdata;
    }
    private void Start()
    {
    }
    void UpdateFrame()
    {
    }
}
