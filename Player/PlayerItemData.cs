using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemData : MonoBehaviour
{
    List<ItemData> playerItems;


    public void PlayerItemAssign(ItemData data)
    {
        playerItems.Add(data);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
