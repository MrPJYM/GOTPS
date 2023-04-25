using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    static public PlayerInput instance;
    [SerializeField]
    private float wheelSpeed;
    [SerializeField]
    [Range(0.0f, 5.0f)]
    private float rotateSpeedX;
    [SerializeField]
    [Range(0.0f, 5.0f)]
    private float rotateSpeedY;
    public enum KeyWeapon
    {
        None,
        Rifle,
        Swoerd,
        Grenede
    }

    public Vector2 playerMoveinput { get; private set; }
    public Vector2 playerRotateinput { get; private set; }

    public bool IsRun { get; private set; }
    public bool IsMouseLeft { get; private set; }
    public bool IsMouseRight { get; private set; }
    public bool IsMouseWheel { get; private set; }
    public float IsMouseWheelScroll { get; private set; }

    public bool IsSkillQ { get; private set; }
    public bool IsSkillE { get; private set; }
    public bool IsSkillR { get; private set; }

    public bool IsInterativeF { get; private set; }

    public bool IsInvectory { get; private set; }
    public bool IsCharacterInfo { get; private set; }
    public bool IsSkillInfo { get; private set; }
    public bool IsMapInfo { get; private set; }
    public bool IsCroud { get; private set; }
    public bool IsJump { get; private set; }
    public Dictionary<KeyCode, int> GetItemKeyCode { get; private set; }
    public int IsNumKey { get; private set; }
    public bool IsCameraMove { get; private set; }
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    void Start()
    {
        GetItemKeyCode = new Dictionary<KeyCode, int>()
        {
            [KeyCode.Alpha0] = 0,
            [KeyCode.Alpha1] = 1,
            [KeyCode.Alpha2] = 2,
            [KeyCode.Alpha3] = 3,
            [KeyCode.Alpha4] = 4,
            [KeyCode.Alpha5] = 5,
            [KeyCode.Alpha6] = 6,
            [KeyCode.Alpha7] = 7,
            [KeyCode.Alpha8] = 8,
            [KeyCode.Alpha9] = 9
        };
    }

    // Update is called once per frame
    void Update()
    {
        playerMoveinput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (playerMoveinput.sqrMagnitude > 1)
            playerMoveinput = playerMoveinput.normalized;
        playerRotateinput = new Vector2(-Input.GetAxis("Mouse Y") * rotateSpeedY, Input.GetAxis("Mouse X") * rotateSpeedX);
        //playerRotateinput = new Vector2(Input.GetAxis("Mouse X") * rotateSpeedX, -Input.GetAxis("Mouse Y") * rotateSpeedY);
        IsRun = Input.GetKey(KeyCode.LeftShift);
        IsJump = Input.GetKeyDown(KeyCode.Space);
        IsCroud = Input.GetKeyDown(KeyCode.LeftControl);
        IsSkillE = Input.GetKeyDown(KeyCode.E);
        IsSkillQ = Input.GetKeyDown(KeyCode.Q);
        IsSkillR = Input.GetKeyDown(KeyCode.R);
        IsMouseLeft = Input.GetMouseButton(0);
        IsMouseRight = Input.GetMouseButton(1);
        IsMouseWheel = Input.GetMouseButtonDown(2);
        IsMouseWheelScroll = Input.GetAxis("Mouse ScrollWheel") * wheelSpeed;
        IsCharacterInfo = Input.GetKeyDown(KeyCode.C);
        IsInvectory = Input.GetKeyDown(KeyCode.I);
        IsMapInfo = Input.GetKeyDown(KeyCode.M);
        IsSkillInfo = Input.GetKeyDown(KeyCode.K);
        IsCameraMove = Input.GetKey(KeyCode.BackQuote);
        IsInterativeF = Input.GetKeyDown(KeyCode.F);
        if (Input.anyKey)
        {
            foreach (var key in GetItemKeyCode)
            {
                if (Input.GetKeyDown(key.Key))
                {
                    IsNumKey = key.Value;
                    break;
                }
                else
                    IsNumKey = -1;
            }
        }
    }
}
