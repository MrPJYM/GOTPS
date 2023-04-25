using UnityEngine;

public class PlayerData : UnitBaseData
{
    uint exp;
    uint gold;
    public uint Avoidance;
    public float RecoverSp;
    public int Sp;
    uint skillPoint = 0;
    uint statPoint = 0;

    public Vector3 RecentPosition;
    public int RecentLocation;
    public new uint Exp
    {
        get { return exp; }
        set
        {
            if (value < 0)
                exp = 0;
            else
                exp = value;
        }
    }
    public uint Gold
    {
        get { return gold; }
        set
        {
            if (value < 0)
                gold = 0;
            else
                gold = value;
        }
    }
    public uint SkillPoint
    {
        get { return skillPoint; }
        set
        {
            if (value < 0)
                skillPoint = 0;
            else
                skillPoint = value;
        }
    }

    public uint StatePoint
    {
        get { return statPoint; }
        set
        {
            if (value < 0)
                statPoint = 0;
            else
                statPoint = value;
        }
    }
}
