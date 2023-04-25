using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    List<ItemObj> currentitems;
    BaseState currentState;
    List<BaseState> states;
    public InventoryObj boxInventory;
    public void SwitchState(int next)
    {
        if (!currentState.Equals(states[next]))
        {
            currentState.OnExit();
            currentState = states[next];
            states[next].OnEnter();
        }
    }
    void Start()
    {
        states = new List<BaseState>()
        {
            new OpenBox(),
            new CloseBox()
        };
        currentState = states[1];
        currentState.OnEnter();
        getItem(LoadManager.instance.items["item_potion_hp_01"], 0);
    }
    public void getItem(ItemData item, int num)
    {
        //boxInventory.inventorySlot[num].OnAssignEvent();
    }
    public void OpneBox()
    {
        SwitchState(0);
        boxInventory.transform.parent.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (StateAction.STATE_ACTION_NEXT.Equals(currentState.OnUpdate()) && boxInventory.transform.parent.gameObject.activeInHierarchy)
        {
            SwitchState(1);
            boxInventory.transform.parent.gameObject.SetActive(false);
        }
    }
}

public class CloseBox : BaseState
{
    public CloseBox() : base()
    {
    }
    public override void OnEnter()
    {

    }
    public override StateAction OnUpdate()
    {
        return StateAction.STATE_ACTION_WAIT;
    }
}

public class OpenBox : BaseState
{
    public OpenBox() : base()
    {
    }
    public override StateAction OnUpdate()
    {
        if (PlayerInput.instance.IsInterativeF)
            return StateAction.STATE_ACTION_NEXT;
        else
            return StateAction.STATE_ACTION_WAIT;
    }
}