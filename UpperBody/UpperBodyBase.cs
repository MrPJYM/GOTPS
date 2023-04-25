using UnityEngine;
public enum UpperBodyStates
{
    ThrowGrenedeState,
    digState,
    FireState,
    AimmingState,
    ShoulderHoldState,
    UpperIdleState,
    WeaponChangeState,
    CollectItemState
}
public class ThrowGrenedeState : BaseState
{
    float timer;
    public ThrowGrenedeState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnEnter()
    {
        control.animator.SetTrigger("Grenade");
        control.WM.currentObj.SetActive(false);
        timer = 3f;
    }
    public override StateAction OnUpdate()
    {
        if (timer <= 0f)//control.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            return StateAction.STATE_ACTION_NEXT;
        else
        {
            timer -= Time.deltaTime;
            return StateAction.STATE_ACTION_WAIT;
        }
    }
    public override void OnExit()
    {
        control.WM.currentObj.SetActive(true);
    }
}

public class digState : BaseState
{
    public digState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnEnter()
    {
    }
    public override StateAction OnUpdate()
    {
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}

public class FireState : BaseState
{
    public FireState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnEnter()
    {
        if (control.WM.currentWeaponActive.TryFire())
        {
            control.animator.SetTrigger("Shoot");
        }
    }
    public override StateAction OnUpdate()
    {
        if (PlayerInput.instance.IsMouseLeft)
        {
            if (control.WM.currentWeaponActive.TryFire())
            {
                control.animator.SetTrigger("Shoot");
            }
        }
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}

public class AimmingState : BaseState
{
    public AimmingState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnEnter()
    {
        control.animator.SetInteger("UpperState", 1);
        control.virtualCamera.m_Lens.FieldOfView = 55f;
    }
    public override StateAction OnUpdate()
    {
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}

public class ShoulderHoldState : BaseState
{
    public ShoulderHoldState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnEnter()
    {
        control.animator.SetInteger("UpperState", 2);
        control.virtualCamera.m_Lens.FieldOfView = 65f;
    }
    public override StateAction OnUpdate()
    {
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}

public class UpperIdleState : BaseState
{
    public UpperIdleState(CharacterControl characterC) : base() { control = characterC; }

    public override void OnEnter()
    {
        control.animator.SetLayerWeight(1, 0);
    }
    public override StateAction OnUpdate()
    {
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
        control.animator.SetLayerWeight(1, 1);
    }
}
public class WeaponChangeState : BaseState
{
    float timer;
    int num;
    public WeaponChangeState(CharacterControl characterC) : base() { control = characterC; }// weapon = change_weapon_; num = i; }
    public override void OnEnter()
    {
        control.animator.SetInteger("WeaponType", PlayerInput.instance.IsNumKey);
        num = PlayerInput.instance.IsNumKey;
        timer = 1.5f;
    }
    public override StateAction OnUpdate()
    {
        if (timer <= 0f)
        {
            return StateAction.STATE_ACTION_NEXT;
        }
        else
        {
            timer -= Time.deltaTime;
            return StateAction.STATE_ACTION_WAIT;
        }
    }
    public override void OnExit()
    {
        control.WM.WeaponChange(num);
    }
}
public class SearchItem : BaseState
{
    public SearchItem(CharacterControl character) : base() { control = character; }
    public override void OnEnter()
    {

    }
    public override StateAction OnUpdate()
    {

        return base.OnUpdate();
    }
}


public class CollectItemState : BaseState
{
    public CollectItemState(CharacterControl character) : base() { control = character; }
    public override void OnEnter()
    {
        control.animator.SetTrigger("ItemCollect");
    }
}