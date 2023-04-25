public class WeaponObj : ItemObj
{
    public WeaponData Wdata;
    public WeaponObj(ItemData setdata, WeaponData setWdata) : base(setdata) { Wdata = setWdata; }
    public void Setting(ItemData setdata, WeaponData setWdata)
    {
        data = setdata;
        Wdata = setWdata;
    }
    void Start()
    {

    }
    void Update()
    {

    }
}
