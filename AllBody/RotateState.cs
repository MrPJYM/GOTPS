using UnityEngine;


public struct CameraSetting
{
    public float moveSpeed;
}
public class ChracterRotateState : BaseState
{
    float RotateSpeed;
    float xAxis, yAxis;
    public ChracterRotateState(float Speed, CharacterControl characterC) : base() { RotateSpeed = Speed; control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
    }
    public override StateAction OnUpdate()
    {
        xAxis = PlayerInput.instance.playerRotateinput.y;
        yAxis = PlayerInput.instance.playerRotateinput.x;
        float deg = Mathf.Atan2(xAxis, 16f) * Mathf.Rad2Deg;
        obj.transform.rotation = Quaternion.Euler(0f, obj.transform.rotation.eulerAngles.y + deg, 0f);
        float deg2 = Mathf.Atan2(yAxis, 9f) * Mathf.Rad2Deg;
        //xAxis = Mathf.Clamp(control.virtualCamera.LookAt.rotation.eulerAngles.x + deg2, -30f, 30f);
        control.virtualCamera.LookAt.localRotation = Quaternion.Euler(control.virtualCamera.LookAt.rotation.eulerAngles.x + deg2,
            0f, 0f);


        //Vector3 eulerAngle = new Vector3();
        //eulerAngle.x = -yAxis;
        //eulerAngle.y = xAxis;

        //newX = Mathf.Repeat(xAxis, 360f);
        //newY = Mathf.Clamp(newY, cameraSettings.minAngle, cameraSettings.maxAngle);


        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
    }
}

public class CameraRotateState : BaseState
{
    float RotateSpeed;
    float xAxis, yAxis;
    public CameraRotateState(float Speed, CharacterControl characterC) : base() { RotateSpeed = Speed; control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
    public override void OnEnter()
    {
    }
    public override StateAction OnUpdate()
    {
        xAxis = PlayerInput.instance.playerRotateinput.y;
        yAxis = PlayerInput.instance.playerRotateinput.x;
        float deg = Mathf.Atan2(xAxis, 16f) * Mathf.Rad2Deg;
        float deg2 = Mathf.Atan2(yAxis, 9f) * Mathf.Rad2Deg;
        //xAxis = Mathf.Clamp(deg2, -40f, 40f);    
        control.virtualCamera.LookAt.localRotation = Quaternion.Euler(control.virtualCamera.LookAt.transform.localEulerAngles.x + deg2,
            control.virtualCamera.LookAt.transform.localEulerAngles.y + deg, 0f);
        return StateAction.STATE_ACTION_NEXT;
    }
    public override void OnExit()
    {
        obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, control.virtualCamera.LookAt.transform.eulerAngles.y, obj.transform.eulerAngles.z);//방향전환
    }
}

public class NoneRotateState : BaseState
{
    public NoneRotateState(CharacterControl characterC) : base() { control = characterC; }
    public override void OnAwake()
    {
        obj = control.gameObject;
    }
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
//void Rotate()
//{
//    xAxis = PlayerInput.instance.playerRotateinput.y;
//    yAxis = PlayerInput.instance.playerRotateinput.x;
//    float deg = Mathf.Atan2(xAxis, 16f) * Mathf.Rad2Deg;
//    //obj.transform.rotation = Quaternion.Euler(0f, obj.transform.rotation.eulerAngles.y + deg, 0f);
//    float deg2 = Mathf.Atan2(yAxis, 9f) * Mathf.Rad2Deg;
//    control.virtualCamera.LookAt.localRotation = Quaternion.Euler(control.virtualCamera.LookAt.rotation.eulerAngles.x + deg2,
//        control.virtualCamera.LookAt.rotation.eulerAngles.y + deg, 0f);
//    //control.virtualCamera.LookAt.localRotation = Quaternion.Euler(control.virtualCamera.LookAt.rotation.eulerAngles.x + deg2, 0f, 0f);
//}