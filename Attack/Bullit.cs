using UnityEngine;

public class Bullit : MonoBehaviour
{
    public float Speed;
    public float lifeTime;
    public BoxCollider box;
    public RifleActive RA;
    private void OnEnable()
    {
        Speed = 1f;
        lifeTime = 2f;
    }
    public void returnThis()
    {
        BulltObjpool.ReturnObject(this);
        HitManager.instance.bulletColliders.Remove(this);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            returnThis();
        }
    }
}
