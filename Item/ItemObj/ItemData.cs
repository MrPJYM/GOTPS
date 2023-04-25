using System.Collections.Generic;
using UnityEngine;


public enum Category
{
    EQUIP,
    CONSUMABLE,
    DEFALUT
}

public enum ItemGrade
{
    NORMAL,
    RARE,
    EPIC,
    UNIQUE
}
public enum EquipmentType
{
    NULL,
    WEAPON,
    ARMOR,
    SHIELD,
    GLOVES,
    HELMET,
    PANTS,
    BELT,
    BOOTS,
    RING
}

public class ItemData
{
    public int Id;
    //개발장비이름
    public string Name;
    //장비이름
    public string STR;
    public string STR_String;
    //설명
    public string DESC;
    public string DESC_String;
    //카테고리,장착,등급
    public Category Category;
    public EquipmentType Type;
    public ItemGrade Grade;
    //스탯
    public int Ap;
    public int Dp;
    public int Accuracy;
    public int Dodge;
    //효과들
    public List<EffectArray> EffectArray;
    public float Time;
    public float CoolTime;
    //클래스장착여부
    public bool Knight;
    public bool Archer;
    public bool Wizard;
    //string Icon;
    public int Price;
    public string item_Sprite_Name;
    public Sprite item_Sprite;
    public string itemPrefebName;
    public override bool Equals(object obj)
    {
        ItemData target = obj as ItemData;
        if (obj == null) return false;
        return Category == target.Category &&
                Type == target.Type &&
                Id == target.Id;
    }
    public static bool operator ==(ItemData lhs, ItemData rhs)
    {
        if (lhs is null)
            return ReferenceEquals(lhs, null);
        if (rhs is null)
            return ReferenceEquals(rhs, null);
        return lhs.Category == rhs.Category &&
                lhs.Type == rhs.Type &&
               lhs.Id == rhs.Id;
    }
    public static bool operator !=(ItemData lhs, ItemData rhs) => !(lhs == rhs);
}
