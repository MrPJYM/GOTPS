
public struct EffectArray
{
    string? Effet;
    int? Value;
    float? Time;
    public EffectArray(string? e, int? i, float? t) { Effet = e; Value = i; Time = t; }
}
public enum itemType
{
    POTION,
    DEFALUT
}
public class ItemLoad : DataParser<ItemLoad, ItemData>
{
    public override void ReadDate(string[] _datas)
    {
        ItemData tmp = new ItemData();
        tmp.Id = int.Parse(_datas[0]);
        tmp.Name = _datas[1];
        tmp.STR = _datas[2];
        tmp.DESC = _datas[3];
        tmp.Category = (Category)System.Enum.Parse(typeof(Category), _datas[4]);
        if (tmp.Category == Category.EQUIP)
            tmp.Type = (EquipmentType)System.Enum.Parse(typeof(EquipmentType), _datas[5]);
        else
            tmp.Type = EquipmentType.NULL;
        tmp.Grade = (ItemGrade)System.Enum.Parse(typeof(ItemGrade), _datas[6]);
        tmp.Ap = int.Parse(_datas[7]);
        tmp.Dp = int.Parse(_datas[8]);
        tmp.Accuracy = int.Parse(_datas[9]);
        tmp.Dodge = int.Parse(_datas[10]);
        tmp.EffectArray = new System.Collections.Generic.List<EffectArray>
        {
            new EffectArray(_datas[11],int.Parse(_datas[12]),float.Parse(_datas[13])),
            new EffectArray(_datas[14],int.Parse(_datas[15]),float.Parse(_datas[16])),
            new EffectArray(_datas[17],int.Parse(_datas[18]),float.Parse(_datas[19]))
        };
        tmp.CoolTime = float.Parse(_datas[20]);
        tmp.Knight = bool.Parse(_datas[21]);
        tmp.Archer = bool.Parse(_datas[22]);
        tmp.Wizard = bool.Parse(_datas[23]);
        tmp.item_Sprite_Name = _datas[24];
        tmp.Price = int.Parse(_datas[25]);
        tmp.itemPrefebName = _datas[26];
        base.AddData(tmp);
    }
}

public class ItemStringLoad : DataParser<ItemStringLoad, string>
{
    public System.Collections.Generic.Dictionary<string, string> Strings = new System.Collections.Generic.Dictionary<string, string>();

    public override void ReadDate(string[] _datas)
    {
        Strings.Add(_datas[0], _datas[1]);
    }
}