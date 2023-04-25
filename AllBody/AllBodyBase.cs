using UnityEngine;

public enum StateAction
{
    STATE_ACTION_WAIT,
    STATE_ACTION_NEXT,
    STATE_ACTION_PASS
}
public enum AllBodyStates
{
    WalkState,
    RunState,
    IdleState,
    croudState,
    croudChangeState,
    jumpState
}
public abstract class BaseState
{
    protected CharacterControl control;
    protected GameObject obj;
    public BaseState() { }
    public virtual void OnAwake() { }
    public virtual void OnEnter() { }
    public virtual StateAction OnUpdate() { return StateAction.STATE_ACTION_NEXT; }
    public virtual void OnExit() { }
}
public class WalkState : BaseState
{
    float MoveSpeed;
    Vector3 moveDirection;
    public float currentVelocityY;
    public float currentSpeed => new Vector2(CharacterControl.instance.characterController.velocity.x, CharacterControl.instance.characterController.velocity.z).magnitude;
    float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float xAxis, yAxis;
    public WalkState(float Speed, CharacterControl characterC) : base() { MoveSpeed = Speed; control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
        control.animator.SetInteger("WalkState", 1);
    }
    public override StateAction OnUpdate()
    {
        var targetSpeed = MoveSpeed * control.input.magnitude;
        moveDirection = Vector3.Normalize(obj.transform.forward * control.input.y + obj.transform.right * control.input.x); //방향
        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);//원래값(currentSpeed)에서 목표값(targetSpeed)으로 변화하는 직전까지의 값에 지연시간을 적용해 부드럽게 이어지도록.SmoothDamp는 값을 부드럽게 변화시킴
        currentVelocityY += Physics.gravity.y * Time.deltaTime; //시간에 따라 중력값만큼 밑으로 이동하는 힘 적용
        Vector3 velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY; //속도를 두가지로 나누어 앞/옆 그리고 위로 따로 계산하여 마지막에 합친것(이렇게 해야 점프때 currentVelocityY로 따로 계산할 수 있음)
        control.characterController.Move(velocity * Time.deltaTime);
        if (control.IsGrounded())
        {
            currentVelocityY = 0;
        }
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}
public class RunState : BaseState
{
    float MoveSpeed;
    Vector3 moveDirection;
    public float currentVelocityY;
    public float currentSpeed => new Vector2(control.characterController.velocity.x, control.characterController.velocity.z).magnitude;
    float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float xAxis, yAxis;

    public RunState(float Speed, CharacterControl characterC) : base() { MoveSpeed = Speed; control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
        control.animator.SetInteger("WalkState", 2);

    }
    public override StateAction OnUpdate()
    {
        var targetSpeed = MoveSpeed * control.input.magnitude;
        moveDirection = Vector3.Normalize(obj.transform.forward * control.input.y + obj.transform.right * control.input.x); //방향
        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);//원래값(currentSpeed)에서 목표값(targetSpeed)으로 변화하는 직전까지의 값에 지연시간을 적용해 부드럽게 이어지도록.SmoothDamp는 값을 부드럽게 변화시킴
        currentVelocityY += Physics.gravity.y * Time.deltaTime; //시간에 따라 중력값만큼 밑으로 이동하는 힘 적용
        Vector3 velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY; //속도를 두가지로 나누어 앞/옆 그리고 위로 따로 계산하여 마지막에 합친것(이렇게 해야 점프때 currentVelocityY로 따로 계산할 수 있음)
        control.characterController.Move(velocity * Time.deltaTime);
        if (control.IsGrounded())
        {
            currentVelocityY = 0;
        }
        return StateAction.STATE_ACTION_NEXT;
    }
}
public class IdleState : BaseState
{
    float xAxis, yAxis;
    public IdleState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
        control.animator.SetInteger("WalkState", 0);
    }
    public override StateAction OnUpdate()
    {
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}
public class croudState : BaseState
{
    float MoveSpeed;
    Vector3 moveDirection;
    public float currentVelocityY;
    public float currentSpeed => new Vector2(control.characterController.velocity.x, control.characterController.velocity.z).magnitude;
    float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float xAxis, yAxis;
    public croudState(float Speed, CharacterControl characterC) : base() { MoveSpeed = Speed; control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
        control.animator.SetInteger("WalkState", 4);
    }
    public override StateAction OnUpdate()
    {
        var targetSpeed = MoveSpeed * control.input.magnitude;
        moveDirection = Vector3.Normalize(obj.transform.forward * control.input.y + obj.transform.right * control.input.x); //방향
        targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);//원래값(currentSpeed)에서 목표값(targetSpeed)으로 변화하는 직전까지의 값에 지연시간을 적용해 부드럽게 이어지도록.SmoothDamp는 값을 부드럽게 변화시킴
        currentVelocityY += Physics.gravity.y * Time.deltaTime; //시간에 따라 중력값만큼 밑으로 이동하는 힘 적용
        Vector3 velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY; //속도를 두가지로 나누어 앞/옆 그리고 위로 따로 계산하여 마지막에 합친것(이렇게 해야 점프때 currentVelocityY로 따로 계산할 수 있음)
        control.characterController.Move(velocity * Time.deltaTime);
        if (control.IsGrounded())
        {
            currentVelocityY = 0;
        }
        return StateAction.STATE_ACTION_NEXT;
    }

    public override void OnExit()
    {
    }
}
public class croudChangeState : BaseState
{
    delegate StateAction Do();
    Do @do;
    AnimatorStateInfo info;
    float time;
    float xAxis, yAxis;
    bool upDown;
    public croudChangeState(CharacterControl characterC, bool updown) : base() { control = characterC; upDown = updown; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
        if (upDown)
            control.animator.SetInteger("WalkState", 4);
        else
            control.animator.SetInteger("WalkState", 0);
        @do = check;
    }
    public override StateAction OnUpdate()
    {
        return @do();
    }
    StateAction check2()
    {
        if (time <= 0f)
        {
            return StateAction.STATE_ACTION_NEXT;
        }
        else
        {
            time -= Time.deltaTime;
            return StateAction.STATE_ACTION_WAIT;
        }
    }
    StateAction check()
    {
        if (control.animator.GetCurrentAnimatorStateInfo(0).IsName("idle to crouch") || control.animator.GetCurrentAnimatorStateInfo(0).IsName("crouch to idle"))
        {
            time = control.animator.GetCurrentAnimatorStateInfo(0).length;
            @do = check2;
        }
        return StateAction.STATE_ACTION_WAIT;
    }
    public override void OnExit()
    {
        @do = null;
    }
}
public class jumpState : BaseState
{
    float MoveSpeed;
    Vector3 moveDirection;
    float height;
    float currentVelocityY;
    public float currentSpeed => new Vector2(control.characterController.velocity.x, control.characterController.velocity.z).magnitude;
    float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    public jumpState(float setHeight, float Speed, CharacterControl characterC) : base() { height = setHeight; MoveSpeed = Speed; control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
        control.animator.SetTrigger("Jump");
        Jumpgo();
        control.animator.SetBool("OnJump", true);
    }
    public override StateAction OnUpdate()
    {
        if (control.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f && control.IsGrounded())
        {
            currentVelocityY = 0;
            control.animator.SetBool("OnJump", false);
            return StateAction.STATE_ACTION_NEXT;
        }
        else
        {
            var targetSpeed = MoveSpeed * control.input.magnitude;
            moveDirection = Vector3.Normalize(obj.transform.forward * control.input.y + obj.transform.right * control.input.x); //방향
            targetSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);//원래값(currentSpeed)에서 목표값(targetSpeed)으로 변화하는 직전까지의 값에 지연시간을 적용해 부드럽게 이어지도록.SmoothDamp는 값을 부드럽게 변화시킴
            currentVelocityY += Physics.gravity.y * Time.deltaTime; //시간에 따라 중력값만큼 밑으로 이동하는 힘 적용
            Vector3 velocity = moveDirection * targetSpeed + Vector3.up * currentVelocityY; //속도를 두가지로 나누어 앞/옆 그리고 위로 따로 계산하여 마지막에 합친것(이렇게 해야 점프때 currentVelocityY로 따로 계산할 수 있음)
            control.characterController.Move(velocity * Time.deltaTime);
            if (control.IsGrounded())
            {
                currentVelocityY = 0;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
    }
    public void Jumpgo()
    {
        currentVelocityY = 0;
        currentVelocityY += Mathf.Sqrt(height * -3.0f * Physics.gravity.y);
    }
    public override void OnExit()
    {
        currentVelocityY = 0;
    }
}


