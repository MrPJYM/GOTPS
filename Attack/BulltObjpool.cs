using System.Collections.Generic;
using UnityEngine;
public class BulltObjpool : MonoBehaviour
{
    public static BulltObjpool Instance;
    static Dictionary<GameObject, Queue<Bullit>> poolingObjectQueue = new Dictionary<GameObject, Queue<Bullit>>();
    List<GameObject> poolingObjectPrefab;
    int initCount = 20;
    /*private void Initialize(int initCount)
    {
        foreach (var data in poolingObjectPrefab)
        {
            poolingObjectQueue.Add(data, new Queue<Bullit>());
        }
        foreach (var Queue in poolingObjectQueue)
        {
            for (int i = 0; i < initCount; i++)
            {
                Queue.Value.Enqueue(CreateNewObject(Queue.Key));
            }
        }
    }*/
    public void AddPrefab(GameObject obj)
    {
        Bullit bullit = null;
        if (!obj.TryGetComponent<Bullit>(out bullit))
        {
            bullit = obj.AddComponent<Bullit>();
        }
        bullit.box = obj.AddComponent<BoxCollider>();
        bullit.box.isTrigger = true;
        GameObject newobj = Instantiate(obj, transform);
        newobj.SetActive(false);
        newobj.name = obj.name;
        poolingObjectPrefab.Add(newobj);
        poolingObjectQueue.Add(newobj, new Queue<Bullit>());
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectQueue[newobj].Enqueue(CreateNewObject(newobj));
        }
    }
    private Queue<Bullit> FindQueue(GameObject obj)
    {
        foreach (var data in poolingObjectQueue)
        {
            if (data.Key.name.Equals(obj.name))
                return data.Value;
        }
        return null;
    }
    private Bullit CreateNewObject(GameObject obj)
    {
        GameObject newobj = null;
        foreach (var data in poolingObjectPrefab)
        {
            if (data.Equals(obj))
            {
                newobj = Instantiate<GameObject>(data, transform);
                break;
            }
        }
        if (newobj != null)
        {
            var newbullit = newobj.GetComponent<Bullit>();
            newbullit.gameObject.SetActive(false);
            newbullit.transform.SetParent(transform);
            newbullit.gameObject.name = obj.name;
            return newbullit;
        }
        else
            return null;
    }
    public static Bullit GetObject(string name)
    {
        Bullit obj = null;
        foreach (var Queue in poolingObjectQueue)
        {
            if (Queue.Key.name.Equals(name + "(Clone)"))
            {
                if (Queue.Value.Count > 0)
                {
                    obj = Queue.Value.Dequeue();
                    obj.transform.SetParent(null);
                    obj.gameObject.SetActive(true);
                    return obj;
                }
                else
                {
                    var newObj = Instance.CreateNewObject(Queue.Key);
                    newObj.gameObject.SetActive(true);
                    newObj.transform.SetParent(null);
                    return newObj;
                }
            }
        }
        return null;
    }

    public static void ReturnObject(Bullit obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.FindQueue(obj.gameObject).Enqueue(obj);
    }
    private void Awake()
    {
        Instance = this;
        poolingObjectPrefab = new List<GameObject>();
    }
    void Start()
    {
        LoadManager.instance.SetBullit();
        //Initialize(5);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
