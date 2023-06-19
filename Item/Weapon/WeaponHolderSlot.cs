using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderSlot : MonoBehaviour
{
    public Transform parentOverride;
    public bool isFirstSlot;
    public bool isSecondSlot;
    public bool isThirdlot;

    public GameObject currentWeaponModel;

    public void UnloadWeapon()
    {
        if(currentWeaponModel!=null)
        {
            currentWeaponModel.SetActive(false);
        }
    }

    public void UnloadWeaponAndDestroy()
    {
        if(currentWeaponModel!=null)
        {
            Destroy(currentWeaponModel);
        }
    }

    public void LoadWeaponModel(ItemData weaponData)//WeaponItem weaponItem)
    {
        UnloadWeaponAndDestroy();
        if(weaponData==null)
        {
            UnloadWeapon();
            return;
        }
        //Gamobject Load

        GameObject model = LoadManager.instance.GetPrefeb(weaponData.itemPrefebName,null) as GameObject;
        if(model!=null)
        {
            if(parentOverride!=null)
            {
                model.transform.parent = parentOverride;
            }
            else
            {
                model.transform.parent = transform;
            }

            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }
        currentWeaponModel = model;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
