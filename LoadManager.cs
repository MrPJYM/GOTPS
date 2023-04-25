using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
//using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.AsyncOperations;
public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    [Header("LOADPATH")]
    [SerializeField]
    string WeaponLoadpath;
    [SerializeField]
    string ItemStringpath;
    [SerializeField]
    string Itempath;
    public Dictionary<string, WeaponData> dbRifle = new Dictionary<string, WeaponData>();
    public Dictionary<string, ItemData> items = new Dictionary<string, ItemData>();
    public Dictionary<string, Sprite> item_SpriteLoads = new Dictionary<string, Sprite>();
    public GameObject @parent;
    AssetReference Ref;
    //public AssetLabelReference asset;
    //public List<IResourceLocation> bullitlist;
    public GameObject GetPrefeb(string _name, Transform _parent)
    {
        Ref = new AssetReference(_name);
        return Ref.InstantiateAsync(_parent).WaitForCompletion();
    }
    //public GameObject GetPrefeb(string _name, Vector3 _parent)
    //{
    //    Ref = new AssetReference(_name);
    //    return Ref.InstantiateAsync(_parent, Quaternion.identity).WaitForCompletion();
    //}
    //public void GetBullit()=>Addressables.LoadResourceLocationsAsync(asset).Completed += obj => { bullitlist = new List<IResourceLocation>(obj.Result); };
    public void SetBullit()
    {
        List<string> stringlist = new List<string>();
        List<AssetReference> objs = new List<AssetReference>();
        foreach (var data in dbRifle)
        {
            if (!stringlist.Contains(data.Value.bullitname) && data.Value.bullitname != "N")
            {
                stringlist.Add(data.Value.bullitname);
                try
                {
                    new AssetReference(data.Value.bullitname).InstantiateAsync().Completed += completedBullit;
                }
                catch (UnityException e) { }
            }
        }
    }
    void completedBullit(AsyncOperationHandle<GameObject> handle)
    {
        BulltObjpool.Instance.AddPrefab(handle.Result);
        Addressables.Release(handle);
    }
    void ItemAllLoad()
    {
        Debug.Log(LoadManager.instance.items["AR_n_01"].STR);
        Debug.Log(dbRifle.Count);
        List<ItemData> datas = ItemLoad.instance.returnList();
        foreach(var data in datas)
        {
            AssetReferenceSprite asset = new AssetReferenceSprite(data.item_Sprite_Name);
            asset.LoadAssetAsync<Sprite>().WaitForCompletion();
            data.item_Sprite = asset.Asset as Sprite;
        }
        /*Dictionary<string, string> pairs = ItemStringLoad.instance.Strings;
        foreach (var data in datas)
        {
            data.STR_String =pairs[data.STR];
            data.DESC_String = pairs[data.DESC];
            if (data.Type == ItemType.WEAPON) {
                foreach(var weapon in dbRifle)
                {
                    if(weapon.gunName==data.Name)
                    {
                        weapons.Add(new WeaponObj(data, weapon));
                        break;
                    }
                }
                data.item_Sprite = GetSprite(data.itemPrefebName);
            }else if(data.Type==ItemType.POTION)
            {
                items.Add(new ItemObj(data));
                data.item_Sprite = GetSprite(data.itemPrefebName);
            }
        }*/
    }
    void Awake()
    {
        if(instance==null)
            instance = this;

        WeaponLoad.instance.LoadData(Application.dataPath + "/" + WeaponLoadpath);
        foreach (var data in WeaponLoad.instance.returnList())
        {
            dbRifle.Add(data.gunName, data);
        }
        ItemStringLoad.instance.LoadData(Application.dataPath + "/" + ItemStringpath);
        ItemLoad.instance.LoadData(Application.dataPath + "/" + Itempath);
        foreach (var data in ItemLoad.instance.returnList())
        {
            items.Add(data.Name, data);
        }
        ItemAllLoad();
    }
    private void Start()
    {

    }
    void Update()
    {

    }
}
