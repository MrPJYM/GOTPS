public class WeaponLoad : DataParser<WeaponLoad, WeaponData>
{
    public override void ReadDate(string[] _datas)
    {
        WeaponData tmp = new WeaponData();
        tmp.gunName = _datas[1];
        tmp.type = (Weapon_Type)System.Enum.Parse(typeof(Weapon_Type), _datas[2]);
        tmp.range = float.Parse(_datas[3]);
        tmp.accuracy = float.Parse(_datas[4]);
        tmp.fireRate = float.Parse(_datas[5]);
        tmp.reloadTime = float.Parse(_datas[6]);
        tmp.damage = int.Parse(_datas[7]);
        tmp.area = int.Parse(_datas[8]);
        tmp.bullitname = _datas[9];
        tmp.rootName = _datas[10];
        base.AddData(tmp);
    }
    //public override WeaponData returnSingleName(string name)
    //{
    //    //return list.Find(o => o.Equals(name));
    //}
}

