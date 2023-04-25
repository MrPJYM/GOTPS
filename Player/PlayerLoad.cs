using UnityEngine;

public class PlayerLoad : DataParser<PlayerLoad, PlayerData>
{
    public override void ReadDate(string[] _datas)
    {
        PlayerData tmp = new PlayerData();
        tmp.Name = _datas[0];
        tmp.Level = uint.Parse(_datas[1]);
        tmp.Hp = uint.Parse(_datas[2]);
        tmp.Mp = uint.Parse(_datas[3]);
        tmp.Def = uint.Parse(_datas[4]);
        tmp.Str = uint.Parse(_datas[5]);
        tmp.Dex = uint.Parse(_datas[6]);
        tmp.Int = uint.Parse(_datas[7]);
        tmp.Lux = uint.Parse(_datas[8]);
        tmp.Exp = uint.Parse(_datas[9]);
        tmp.Sp = int.Parse(_datas[10]);
        tmp.Speed = float.Parse(_datas[11]);
        tmp.AttackSpeed = float.Parse(_datas[12]);
        tmp.CriticalChance = float.Parse(_datas[13]);
        tmp.CriticalMultiplier = float.Parse(_datas[14]);
        tmp.RecoverHp = float.Parse(_datas[15]);
        tmp.RecoverMp = float.Parse(_datas[16]);
        tmp.RecoverSp = float.Parse(_datas[17]);
        tmp.Gold = uint.Parse(_datas[18]);
        tmp.SkillPoint = uint.Parse(_datas[19]);
        tmp.StatePoint = uint.Parse(_datas[20]);
        tmp.Avoidance = uint.Parse(_datas[21]);
        tmp.RecentLocation = int.Parse(_datas[22]);
        tmp.RecentPosition = new Vector3(float.Parse(_datas[23]), float.Parse(_datas[24]), float.Parse(_datas[25]));
        base.AddData(tmp);
    }
}

