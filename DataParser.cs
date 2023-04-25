using System.Collections.Generic;
using System.IO;

public class DataParser<T, Q> where T : class, new() where Q : class
{
    protected List<Q> list;
    static T inst;
    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
    public DataParser()
    {

    }
    public void LoadData(string _fileName)
    {
        list = new List<Q>();
        using (StreamReader sr = new StreamReader(_fileName))
        {
            string line = string.Empty;
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] datas = line.Split(',');
                ReadDate(datas);
            }
            sr.Close();
        }
    }
    public virtual void ReadDate(string[] _datas)
    {
    }
    public void AddData(Q data)
    {
        list.Add(data);
    }
    public List<Q> returnList()
    {
        return list;
    }
    public virtual Q returnSingleName(string name)
    {
        return list.Find(o => o.Equals(name));
    }
}
