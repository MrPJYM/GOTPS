//public enum ItemState
//{
//    FalseState,
//    Collectible,
//    DisCollectible,
//    InventoryState,
//    UseState,
//    EquipState
//}
//public abstract class BaseItemState
//{
//    protected ItemObj item;
//    public ItemState state;
//    public BaseItemState(ItemObj @object) { item = @object; }
//    public virtual void OnAwake() { }
//    public virtual void OnEnter() { }
//    public virtual StateAction OnUpdate() { return StateAction.STATE_ACTION_NEXT; }
//    public virtual void OnExit() { }
//}

//public class FalseState : BaseItemState
//{
//    public FalseState(ItemObj @object) : base(@object) { }
//    public override void OnAwake()
//    {
//        state = ItemState.FalseState;
//    }
//    public override void OnEnter()
//    {
//        //item.gameObject.SetActive(false);      
//    }
//}

//public class Collectible : BaseItemState
//{
//    public Collectible(ItemObj @object) : base(@object)
//    {
//    }
//    public override void OnAwake()
//    {
//        state = ItemState.Collectible;
//    }
//    public override void OnEnter()
//    {
//        item.gameObject.SetActive(true);
//    }
//    public override StateAction OnUpdate()
//    {

//        return StateAction.STATE_ACTION_NEXT;
//    }
//    public override void OnExit()
//    {

//    }
//}
//public class DisCollectible : BaseItemState
//{
//    public DisCollectible(ItemObj @object) : base(@object) { }
//    public override void OnAwake()
//    {
//        state = ItemState.DisCollectible;
//    }
//}

//public class InventoryState : BaseItemState
//{
//    public InventoryState(ItemObj @object) : base(@object) { }
//    public override void OnAwake()
//    {
//        state = ItemState.InventoryState;
//    }
//}

//public class UseState : BaseItemState
//{
//    public UseState(ItemObj @object) : base(@object) { }
//    public override void OnAwake()
//    {
//        state = ItemState.UseState;
//    }
//}
//public class EquipState : BaseItemState
//{
//    public EquipState(ItemObj @object) : base(@object) { }
//    public override void OnAwake()
//    {
//        state = ItemState.EquipState;
//    }
//    public override void OnEnter()
//    {

//    }

//}