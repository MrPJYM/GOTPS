using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public CharacterControl CC;
    //public List<ItemObj> currentItems;
    public ItemData settingItem;
    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {
        /*GameObject obj = LoadManager.instance.GetPrefeb(LoadManager.instance.dbRifle[1].prefebname,new Vector3(10,1,10));
        ItemObj item = obj.AddComponent<ItemObj>();
        RifleActive RA = obj.AddComponent<RifleActive>();
        RA.rifle=obj.AddComponent<Rifle>().SetRifle(LoadManager.instance.dbRifle[1]);
        RA.rifle.muzzleTransform = obj.transform.Find("SKEL_Handgun_03").Find("root").Find("SOCKET_Muzzle");
        RA.GetOut();
        item.collider=obj.AddComponent<BoxCollider>();
        item.collider.isTrigger = true;
        item.SetRifle(RA.rifle);
        item.DataSet(settingItem);
        currentItems.Add(item);*/
        //item.SwitchState(ItemState.Collectible);

    }
    void Update()
    {
        /* foreach(var data in currentItems)
         {
             if(data.collider.bounds.Intersects(CC.characterController.bounds))
             {
                 if (data.type == ItemType.Weapon)
                 {
                     GameObject obj;
                     data.SwitchState(ItemState.EquipState);
                     obj = CC.WM.currentWeaponChange(data.data.rifle.type, data.gameObject);
                     obj.transform.position=CC.transform.position+(
                         Vector3.forward*10);
                     currentItems.Remove(data);
                     currentItems.Add(obj.GetComponent<ItemObj>());
                     CC.SwitchUpperState(7);
                     break;
                 }
             }
         }*/
    }
}
