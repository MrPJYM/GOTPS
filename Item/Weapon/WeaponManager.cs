using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public delegate void WeaponChangeF();
    public WeaponChangeF weaponChangeF = null;
    public Weapon_Type type;
    public Transform Aimpos;
    public RectTransform AimUI;
    public GameObject currentObj;
    public WeaponActive currentWeaponActive;
    public Vector3[] riflePos;
    public Quaternion[] rifleRotation;
    public WeaponActive[] weaponActives;
    public List<EnemyObj> enemyObjs;
    public List<Collider> enemyCollider;
    public WeaponInventoryObj inventoryObj;
    public string[] names;
    public LayerMask layerMask;
    IEnumerator Initialize()
    {
        var ws = new WaitForEndOfFrame();
        yield return ws;
        riflePos = new Vector3[3];
        rifleRotation = new Quaternion[3];
        weaponActives = new WeaponActive[3];

        HitManager.instance.enemyColliders = enemyObjs;
        GameObject obj = new GameObject("0");
        obj.transform.SetParent(transform);
        weaponActives[0] = obj.AddComponent<NothingWeapon>();
        weaponActives[0].WM = this;
        riflePos[0] = Vector3.zero;
        rifleRotation[0] = Quaternion.identity;
        obj.SetActive(false);

        //Component com;
        WeaponObj weapon;
        bool endtrue = true;
        do
        {
            if (LoadManager.instance.items[names[0]].Equals(null))
            {
                foreach (var data in LoadManager.instance.items)
                {
                    Debug.Log(data.Value.Id);
                }
                yield return ws;
            }
            else
            {
                obj = LoadManager.instance.GetPrefeb(LoadManager.instance.items[names[0]].itemPrefebName, transform);
                weapon = obj.AddComponent<WeaponObj>();
                weapon.Setting(LoadManager.instance.items[names[0]], LoadManager.instance.dbRifle[names[0]]);
                weapon.Wdata.muzzleTransform = obj.transform.Find(weapon.Wdata.rootName).Find("root").Find("SOCKET_Muzzle");
                weaponActives[1] = obj.AddComponent<RifleActive>();
                weaponActives[1].rifle = weapon.Wdata;
                weaponActives[1].WM = this;
                obj.AddComponent<BoxCollider>().isTrigger = true;
                riflePos[1] = new Vector3(0.038f, 0.0645f, 0.0193f);
                rifleRotation[1] = new Quaternion(0.663123488f, -0.662217498f, -0.280217141f, -0.207878932f);
                obj.SetActive(false);
                inventoryObj.AssginSlot(0, weapon.data);
                endtrue = false;
            }
        } while (endtrue);
        endtrue = true;
        do
        {
            if (LoadManager.instance.items[names[1]].Equals(null))
                yield return ws;
            else
            {
                obj = LoadManager.instance.GetPrefeb(LoadManager.instance.items[names[1]].itemPrefebName, transform);
                weapon = obj.AddComponent<WeaponObj>();
                weapon.Setting(LoadManager.instance.items[names[1]], LoadManager.instance.dbRifle[names[1]]);
                weaponActives[2] = obj.AddComponent<SwordActive>();
                weaponActives[2].rifle = weapon.Wdata;
                weaponActives[2].WM = this;
                obj.AddComponent<BoxCollider>().isTrigger = true;
                riflePos[2] = new Vector3(0.038f, 0.0645f, 0.0193f);
                rifleRotation[2] = new Quaternion(0.266646177f, -0.642508924f, 0.311507136f, -0.647337258f);
                inventoryObj.AssginSlot(1, weapon.data);
                obj.SetActive(false);
                endtrue = false;
            }
        } while (endtrue);
        currentWeaponActive = weaponActives[0];
        currentObj = weaponActives[0].gameObject;
        currentObj.SetActive(true);

    }
    public void AimUpdate()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(AimUI.position);
        if (Physics.Raycast(ray, out hit, 200f, layerMask))//currentWeaponActive.rifle.range))
        {
            Aimpos.position = hit.point;
            /*if(Physics.Linecast(currentWeaponActive.rifle.muzzleTransform.position,hit.point,out hit))
            {
                Aimpos.position = hit.point;
            }*/
        }
        else
        {
            Aimpos.position = Camera.main.transform.position + (Camera.main.transform.forward * 200f);//currentWeaponActive.rifle.range);
        }
    }
    public void WeaponChange(int num)
    {
        //currentObj.SetActive(false);
        currentWeaponActive = weaponActives[num];
        currentObj = weaponActives[num].gameObject;
        transform.localPosition = riflePos[num];
        transform.localRotation = rifleRotation[num];
        //currentObj.SetActive(true);
    }
    //public GameObject currentWeaponChange(Weapon_Type _Type, GameObject objs)
    //{

    //    //int num;
    //    //switch (_Type)
    //    //{
    //    //    case Weapon_Type.AR:
    //    //        num = 1;
    //    //        break;
    //    //    case Weapon_Type.GUN:
    //    //        num = 1;
    //    //        break;
    //    //    case Weapon_Type.SWORD:
    //    //        num = 2;
    //    //        break;
    //    //    case Weapon_Type.SHOTGUN:
    //    //        num = 1;
    //    //        break;
    //    //    default:
    //    //        return null;
    //    //}
    //    //weaponActives[num] = objs.GetComponent<WeaponActive>();
    //    //currentWeaponActive.GetOut();
    //    //objs.transform.SetParent(transform);
    //    //objs.transform.localPosition = Vector3.zero;
    //    //GameObject returnobj = currentObj;
    //    //currentObj = objs;
    //    //currentWeaponActive = weaponActives[num];
    //    //weaponChangeF();
    //    //return returnobj;
    //}
    public void ChangeWeapon()
    {
        weaponChangeF();
    }
    public void currentObjfalse(int num)
    {
        weaponActives[num].gameObject.SetActive(false);
    }
    public void currentObjtrue(int num)
    {
        weaponActives[num].gameObject.SetActive(true);
    }
    private void Start()
    {
        StartCoroutine("Initialize");
    }
}
public abstract class WeaponActive : MonoBehaviour
{
    public WeaponManager WM { get; set; }
    public WeaponData rifle { get; set; }
    protected float currentFireRate { get; set; }
    //public List<Collider> enemyCollider;
    public virtual bool TryFire() { return false; }
    public virtual void GetOut() { }
}
public class NothingWeapon : WeaponActive
{
    private void Awake()
    {
        rifle = new WeaponData();
    }
    public override bool TryFire()
    {
        return base.TryFire();
    }
}