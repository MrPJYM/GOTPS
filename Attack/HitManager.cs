using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    static public HitManager instance { get; private set; }
    public List<EnemyObj> enemyColliders;
    public List<Bullit> bulletColliders;
    void RayHitFrame()
    {
    }
    private void Awake()
    {
        instance = this;
        enemyColliders = new List<EnemyObj>();
        bulletColliders = new List<Bullit>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var Edata in enemyColliders)
        {
            foreach (var Bdata in bulletColliders)
            {
                if (Edata.collider.bounds.Intersects(Bdata.box.bounds))
                {
                    Edata.EnemyHit(Bdata);
                }
            }
        }
    }

}
