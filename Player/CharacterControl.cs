using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class CharacterControl : MonoBehaviour
{
    public delegate void Do(int i);
    Do @do = null;
    static public CharacterControl instance;
    public CharacterController characterController { get; private set; }
    public Animator animator;
    GameObject player;
    public Vector2 input;
    public float[] Speeds;
    /*walksSpeed;
    runSpeed;
    croudSpeed;
    jumpSpeed;*/
    public float currentMoveSpeed { get; set; }

    public CinemachineVirtualCamera virtualCamera;
    Vector3 currentRotation;
    float xAxis, yAxis;

    [SerializeField]
    float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;

    Vector3 velocity;
    public float currentVelocityY;
    public Vector3 moveDirection;
    public float currentSpeed => new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
    [SerializeField]
    LayerMask groundMask;

    List<BaseState> allBodyState;
    List<BaseState> upperBodyState;
    BaseState currentState;
    BaseState currentUpperState;
    StateAction currentAction;
    StateAction currentUpperAction;
    List<BaseState> rotateState;
    BaseState currentRotateState;

    public WeaponManager WM;
    public Transform RightHand;
    public Transform LeftHand;
    int Keynum = 1;
    public RigBuilder rigBuilder;
    Rig[] rigs;
    [Header("Boxcast Property")]
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask groundLayer;
    PlayerData pd;

    public void SwitchState(int next)
    {
        if (!currentState.Equals(allBodyState[next]))
        {
            currentState.OnExit();
            currentState = allBodyState[next];
            allBodyState[next].OnEnter();
        }
    }
    public void SwitchUpperState(int next)
    {
        if (!currentUpperState.Equals(upperBodyState[next])) //&& StateAction.STATE_ACTION_NEXT.Equals(currentUpperState))
        {
            currentUpperState.OnExit();
            currentUpperState = upperBodyState[next];
            upperBodyState[next].OnEnter();
        }
    }
    public void SwitchRotateState(int next)
    {
        if (!currentRotateState.Equals(rotateState[next]))
        {
            currentRotateState.OnExit();
            currentRotateState = rotateState[next];
            rotateState[next].OnEnter();
        }
    }
    // Update is called once per frame
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        characterController = GetComponent<CharacterController>();
        player = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        currentAction = StateAction.STATE_ACTION_NEXT;
        currentUpperAction = StateAction.STATE_ACTION_NEXT;
        rigBuilder = GetComponent<RigBuilder>();
    }
    void Start()
    {
        boxSize = new Vector3(characterController.radius * Mathf.PI, maxDistance, characterController.radius * Mathf.PI);
        currentMoveSpeed = Speeds[0];
        currentRotation = transform.rotation.eulerAngles;
        allBodyState = new List<BaseState>()
        {
            new IdleState(this),
            new WalkState(Speeds[0],this),
            new RunState(Speeds[1],this),
            new croudState(Speeds[2],this),
            new jumpState(2f,Speeds[3],this),
            new croudChangeState(this,true),
            new croudChangeState(this,false)
        };
        foreach (var data in allBodyState)
            data.OnAwake();
        currentState = allBodyState[0];
        currentState.OnEnter();
        upperBodyState = new List<BaseState>()
        {
            new UpperIdleState(this),
            new AimmingState(this),
            new ThrowGrenedeState(this),
            new digState(this),
            new FireState(this),
            new WeaponChangeState(this),
            new ShoulderHoldState(this),
            new CollectItemState(this)
        };
        currentUpperState = upperBodyState[1];
        currentUpperState.OnEnter();
        foreach (var data in upperBodyState)
            data.OnAwake();
        rotateState = new List<BaseState>()
        {
            new CameraRotateState(0f,this),
            new ChracterRotateState(0f,this),
            new NoneRotateState(this)
        };
        currentRotateState = rotateState[1];
        currentRotateState.OnEnter();
        foreach (var data in rotateState)
            data.OnAwake();
    }
    public bool IsGrounded()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.4f, groundMask)) return true;
        return false;*/
        return characterController.isGrounded;
        //return Physics.BoxCast(transform.position, boxSize, -transform.up, transform.rotation, maxDistance, groundLayer);
    }
    void StateCheck()
    {
        if (PlayerInput.instance.IsCameraMove)
        {
            SwitchRotateState(0);
        }
        else
            SwitchRotateState(1);
        if (currentAction.Equals(StateAction.STATE_ACTION_NEXT))
        {
            @do = SwitchState;
            if (currentState.Equals(allBodyState[5]))
                @do(3);
            else if (currentState.Equals(allBodyState[6]))
                @do(0);
            else if (PlayerInput.instance.IsJump && IsGrounded())
                @do(4);
            else if (PlayerInput.instance.IsCroud)
            {
                if (currentState.Equals(allBodyState[3]))
                    @do(6);
                else
                    @do(5);
            }
            else if (currentState.Equals(allBodyState[3]))
            {

            }
            else
            {
                if (PlayerInput.instance.playerMoveinput.magnitude == 0 || currentState.Equals(allBodyState[4]))
                {
                    @do(0);
                }
                else
                {
                    if (PlayerInput.instance.IsRun)
                        @do(2);
                    else
                        @do(1);
                }
            }
        }
        else
            @do = null;
        if (currentUpperAction.Equals(StateAction.STATE_ACTION_NEXT))
        {
            if ((Keynum == 1 || Keynum == 2))
            {
                if (PlayerInput.instance.IsMouseRight)
                {
                    SwitchUpperState(1);
                }
                else
                {
                    SwitchUpperState(6);
                }
            }
            else if (Keynum == 0)
                SwitchUpperState(0);
            if (PlayerInput.instance.IsSkillE)
            {
                SwitchUpperState(2);
            }
            if (PlayerInput.instance.IsMouseLeft && Keynum != 0)
            {
                SwitchUpperState(4);
            }
            if (PlayerInput.instance.IsNumKey != -1 && Keynum != PlayerInput.instance.IsNumKey)
            {
                Keynum = PlayerInput.instance.IsNumKey;
                if (Keynum == 0)
                {
                    rigBuilder.layers[0].rig.weight = 0;
                    rigBuilder.layers[1].rig.weight = 0;
                }
                else if (Keynum == 1)
                {
                    rigBuilder.layers[0].rig.weight = 1;
                    rigBuilder.layers[1].rig.weight = 0;
                }
                else if (Keynum == 2)
                {
                    rigBuilder.layers[0].rig.weight = 0;
                    rigBuilder.layers[1].rig.weight = 1;
                }
                SwitchUpperState(5);
            }
        }
    }
    public void currentObjfalse(int num)
    {
        WM.currentObjfalse(num);
    }
    public void currentObjtrue(int num)
    {
        WM.currentObjtrue(num);
    }
    private void LateUpdate()
    {
        WM.AimUpdate();
    }
    void Update()
    {
        input = PlayerInput.instance.playerMoveinput;
        currentRotateState.OnUpdate();
        currentAction = currentState.OnUpdate();
        currentUpperAction = currentUpperState.OnUpdate();
        StateCheck();
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);
        Debug.Log("Upper=" + currentUpperState + " : " + "All=" + currentState);
    }
    //Vector3 Cross(Vector3 vec1, Vector3 vec2)
    //{
    //    float u1 = vec1.x;
    //    float u2 = vec1.y;
    //    float u3 = vec1.z;
    //    float v1 = vec2.x;
    //    float v2 = vec2.y;
    //    float v3 = vec2.z;
    //    Vector3 result = new Vector3();
    //    result.x = u2 * v3 - v2 * u3;
    //    result.y = v1 * u3 - u1 * v3;
    //    result.z = u1 * v2 - v1 * u2;
    //    return result;
    //}
    /*public void OnAnimatorIK(int layerIndex)
    {
        CharacterControl.instance.animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0.5f);
        CharacterControl.instance.animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0.1f);

        CharacterControl.instance.animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHand.position);
        CharacterControl.instance.animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHand.rotation);
        CharacterControl.instance.animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0.5f);
        CharacterControl.instance.animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0.1f);

        CharacterControl.instance.animator.SetIKPosition(AvatarIKGoal.RightHand, RightHand.position);
        CharacterControl.instance.animator.SetIKRotation(AvatarIKGoal.RightHand, RightHand.rotation);
    }*/
}
